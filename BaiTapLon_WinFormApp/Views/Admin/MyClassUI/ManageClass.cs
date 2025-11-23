using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Services;
using BaiTapLon_WinFormApp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon_WinFormApp.Views.Admin.MyClassUI
{
    public partial class ManageClass : UserControl
    {
        private List<ClassCard> classCards = new List<ClassCard>();
        private readonly ServiceHub _servicehub;
        private List<(string classCode, string type, int id)> _classData;

        public ManageClass(List<(string classCode, string type, int id)> classData, ServiceHub servicehub)
        {
            InitializeComponent();
            _servicehub = servicehub;

            // Không dùng classData trực tiếp, mà rebuild lại với type đúng
            LoadInitialClassCards();
        }

        // Load lần đầu với type đúng
        private void LoadInitialClassCards()
        {
            try
            {
                // Lấy danh sách lớp học từ service và tính type đúng
                var classes = _servicehub.ClassService.getAllClass();

                _classData = classes
                    .Select(c => (c.ClassCode, GetClassType(c), c.ClassId))
                    .ToList();

                LoadClassCards(_classData);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khi tải danh sách lớp học: {ex.Message}");
            }
        }

        private void LoadClassCards(List<(string classCode, string type, int id)> classData)
        {
            flowPanelClasses.Controls.Clear();
            classCards.Clear();

            foreach (var item in classData)
            {
                ClassCard card = new ClassCard(item.classCode, item.type, item.id);

                // Subscribe to events
                card.CardClick += Card_CardClick;
                card.CardRightClick += Card_CardRightClick; // Context menu (optional)

                classCards.Add(card);
                flowPanelClasses.Controls.Add(card);
            }
        }

        // Click vào card → Xem chi tiết
        private void Card_CardClick(object sender, EventArgs e)
        {
            if (sender is ClassCard card)
            {
                var classClicked = _servicehub.ClassService.getClassById(card.id);
                if (classClicked == null)
                {
                    MessageHelper.ShowError("Không tìm thấy thông tin lớp học.");
                    return;
                }

                // Hiển thị chi tiết lớp học
                ShowClassDetail(classClicked);
            }
        }

        // Right click vào card → Hiển thị context menu với tùy chọn Edit/Delete (Optional)
        private void Card_CardRightClick(object sender, EventArgs e)
        {
            if (sender is ClassCard card)
            {
                var classClicked = _servicehub.ClassService.getClassById(card.id);
                if (classClicked == null) return;

                // Tạo context menu
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                if(classClicked.Status) // Chỉ cho phép edit nếu lớp đang hoạt động
                {
                    ToolStripMenuItem editItem = new ToolStripMenuItem("Chỉnh sửa", null, (s, ev) =>
                    {
                        EditClass(classClicked);
                    });
                    contextMenu.Items.Add(editItem);
                }

                ToolStripMenuItem viewItem = new ToolStripMenuItem("Xem chi tiết", null, (s, ev) =>
                {
                    ShowClassDetail(classClicked);
                });

                ToolStripMenuItem deleteItem = new ToolStripMenuItem("Xóa lớp", null, (s, ev) =>
                {
                    DeleteClass(classClicked);
                });

                contextMenu.Items.Add(viewItem);
                //contextMenu.Items.Add(editItem);
                contextMenu.Items.Add(new ToolStripSeparator());
                contextMenu.Items.Add(deleteItem);

                // Hiển thị context menu tại vị trí chuột
                contextMenu.Show(card, card.PointToClient(Cursor.Position));
            }
        }

        // Hiển thị form chi tiết lớp học
        private void ShowClassDetail(Class classObj)
        {
            flowPanelClasses.Controls.Clear();
            classCards.Clear();
            pnlHeader.Visible = false;

            var classDetailForm = new ClassDetail(_servicehub, classObj) { 
                    onBack = BackToClassList
            };

            // Thêm nút Back để quay lại danh sách
            Button btnBack = new Button
            {
                Text = "← Quay lại",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(120, 40),
                Location = new Point(20, 20),
                Cursor = Cursors.Hand
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += (s, e) => BackToClassList();

            flowPanelClasses.Controls.Add(btnBack);
            flowPanelClasses.Controls.Add(classDetailForm);
        }

        // Chỉnh sửa lớp học
        private void EditClass(Class classObj)
        {
            var editForm = new ClassAddEditForm(_servicehub, classObj);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                MessageHelper.ShowSuccess("Cập nhật lớp học thành công!");

                // Reload danh sách lớp học
                ReloadClassList();
            }
        }

        // Xóa lớp học
        private void DeleteClass(Class classObj)
        {
            var result = MessageHelper.ShowConfirmation(
                $"Bạn có chắc chắn muốn xóa lớp '{classObj.ClassName}'?\n\n" +
                "Cảnh báo: Hành động này không thể hoàn tác!"
            );

            if (!result) return;

            try
            {
                string errorMessage = _servicehub.ClassService.deleteClass(classObj.ClassId);

                if (errorMessage == null)
                {
                    MessageHelper.ShowSuccess($"Đã xóa lớp '{classObj.ClassName}' thành công!");
                    ReloadClassList();
                }
                else
                {
                    MessageHelper.ShowError($"Lỗi khi xóa lớp:\n{errorMessage}");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi: {ex.Message}");
            }
        }

        // Quay lại danh sách lớp học
        private void BackToClassList()
        {
            pnlHeader.Visible = true;
            ReloadClassList();
        }

        // Reload danh sách lớp học
        private void ReloadClassList()
        {
            try
            {
                // Lấy lại danh sách lớp học từ service
                _classData = _servicehub.ClassService.getAllClass()
                    .Select(c => (c.ClassCode, GetClassType(c), c.ClassId))
                    .ToList();

                LoadClassCards(_classData);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khi tải danh sách lớp học: {ex.Message}");
            }
        }

        // Helper method: Xác định type của lớp học
        private string GetClassType(Class classObj)
        {
            // Ví dụ logic xác định type
            if (!classObj.Status)
                return "Đã kết thúc";
            else if (classObj.StartDate > DateOnly.FromDateTime(DateTime.Now))
                return "Sắp diễn ra";
            else if (classObj.EndDate < DateOnly.FromDateTime(DateTime.Now))
                return "Đã kết thúc";
            else
                return "Đang diễn ra";
        }

        // Thêm lớp học mới
        private void btnAddClass_Click(object sender, EventArgs e)
        {
            var classForm = new ClassAddEditForm(_servicehub);

            if (classForm.ShowDialog() == DialogResult.OK)
            {
                MessageHelper.ShowSuccess("Thêm lớp học thành công!");
                ReloadClassList();
            }
        }

        // Nút Edit trên header (nếu có)
        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageHelper.ShowInfo("Vui lòng click vào lớp học cần chỉnh sửa, sau đó nhấn chuột phải và chọn 'Chỉnh sửa'.");
        }
    }
}
