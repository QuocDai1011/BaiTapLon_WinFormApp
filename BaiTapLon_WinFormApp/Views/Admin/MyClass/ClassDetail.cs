using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Services;
using BaiTapLon_WinFormApp.Utils;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon_WinFormApp.Views.Admin.MyClass
{
    public partial class ClassDetail : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private Class _class; // Bỏ readonly để có thể update

        public ClassDetail(ServiceHub serviceHub, Class classes)
        {
            _serviceHub = serviceHub;
            _class = classes;
            InitializeComponent();
            ClassDetail_Load();
        }

        private void ClassDetail_Load()
        {
            // Refresh class data từ database
            RefreshClassData();

            // Load UI
            LoadClassInfo();

            // Load danh sách sinh viên trong lớp
            loadStudentInClass();
        }

        // Refresh class data từ database
        private void RefreshClassData()
        {
            try
            {
                // Lấy lại thông tin lớp học mới nhất từ database
                var updatedClass = _serviceHub.ClassService.getClassById(_class.ClassId);

                if (updatedClass != null)
                {
                    _class = updatedClass;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khi refresh dữ liệu: {ex.Message}");
            }
        }

        // Load thông tin lớp học lên UI
        private void LoadClassInfo()
        {
            lblClassCode.Text = _class.ClassCode;
            lblClassName.Text = _class.ClassName;
            lblCurrentStudent.Text = _class.CurrentStudent.ToString();
            lblMaxStudent.Text = _class.MaxStudent.ToString();
            lblStartDate.Text = _class.StartDate.ToString("dd/MM/yyyy");
            lblEndDate.Text = _class.EndDate.ToString("dd/MM/yyyy");

            // Map ca học sang chuỗi 
            lblShift.Text = _class.Shift switch
            {
                1 => "08:00 - 11:00",
                2 => "14:00 - 17:00",
                3 => "18:00 - 21:00",
                _ => "Không xác định"
            };

            if (!_class.Status)
            {
                lblTitle.Text = "Chi Tiết Lớp Học (Đã kết thúc)";
            }
            else
            {
                lblTitle.Text = "Chi Tiết Lớp Học";
            }

            lblStatus.Text = _class.Status ? "Đang hoạt động" : "Ngừng hoạt động";
            lblNote.Text = string.IsNullOrEmpty(_class.Note) ? "Không có ghi chú" : _class.Note;

            if (string.IsNullOrEmpty(_class.OnlineMeetingLink))
            {
                lblMethod.Text = "Học trực tiếp";
                lblOnlineLink.Visible = false;
                lblTitleOnlineLink.Visible = false;
            }
            else
            {
                lblMethod.Text = "Học online";
                lblOnlineLink.Text = _class.OnlineMeetingLink;
                lblOnlineLink.Visible = true;
                lblTitleOnlineLink.Visible = true;
            }

            if (!_class.Status)
            {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnOpenClass.Visible = true;
            }
            else
            {
                btnAdd.Visible = true;
                btnDelete.Visible = true;
                btnOpenClass.Visible = false;
            }
        }

        private void loadStudentInClass()
        {
            try
            {
                // Lấy lại danh sách sinh viên mới nhất từ database
                var students = _serviceHub.ClassService.getAllStudentByClassId(_class.ClassId);

                dgvStudents.Rows.Clear();

                if (students == null || students.Count == 0)
                {
                    // Không hiện MessageBox ở đây, chỉ để DataGridView trống
                    return;
                }

                int stt = 0;
                foreach (var student in students)
                {
                    int rowIndex = dgvStudents.Rows.Add();
                    var row = dgvStudents.Rows[rowIndex];
                    stt++;

                    // Gán giá trị
                    row.Cells["colSTT"].Value = stt;
                    row.Cells["colId"].Value = student.StudentId;
                    row.Cells["colFullName"].Value = student.FullName;
                    row.Cells["colEmail"].Value = student.Email;
                    row.Cells["colPhoneNumber"].Value = student.PhoneNumber;
                    row.Cells["colDateOfBirth"].Value = student.DateOfBirth;
                    row.Cells["colGender"].Value = student.Gender ? "Nam" : "Nữ";
                    row.Cells["colPhoneNumberOfParent"].Value = student.PhoneNumberOfParents;

                    // Gán tag để truy xuất đối tượng
                    row.Tag = student;

                    // Căn giữa cho tất cả các ô
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khi tải danh sách sinh viên: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Refresh trước khi mở form thêm
            RefreshClassData();

            var studentsInClass = _serviceHub.ClassService.getAllStudentByClassId(_class.ClassId);

            var addStudentForm = new AddStudentsToClassForm(_serviceHub, _class, studentsInClass);

            if (addStudentForm.ShowDialog() == DialogResult.OK)
            {
                // Reload toàn bộ dữ liệu
                ClassDetail_Load();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Reload toàn bộ dữ liệu
            ClassDetail_Load();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            MessageHelper.ShowInfo("Chức năng đang được phát triển.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Xử lý xóa sinh viên
            if (dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedStudent = dgvStudents.CurrentRow;
            string studentName = selectedStudent.Cells["colFullName"].Value?.ToString() ?? "sinh viên này";

            string message = _class.StartDate < DateOnly.FromDateTime(DateTime.Now) ?
                $"Lớp học đã bắt đầu! Bạn có chắc chắn muốn xóa '{studentName}' không ?" :
                $"Bạn có chắc chắn muốn xóa '{studentName}' khỏi lớp không ?";

            if (!MessageHelper.ShowConfirmation(message))
            {
                return;
            }

            try
            {
                int studentId = (int)selectedStudent.Cells["colId"].Value;

                // Gọi service để xóa (đúng thứ tự tham số: classId, studentId)
                string errorMessage = _serviceHub.ClassService.removeStudentFromClass(_class.ClassId, studentId);



                if (errorMessage == null)
                {
                    MessageHelper.ShowSuccess($"Đã xóa '{studentName}' khỏi lớp thành công!");

                    // Reload toàn bộ dữ liệu từ database
                    ClassDetail_Load();
                }
                else
                {
                    MessageHelper.ShowError($"Lỗi khi xóa sinh viên:\n{errorMessage}");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khi xóa sinh viên:\n{ex.Message}");
            }
        }

        private void btnOpenClass_Click(object sender, EventArgs e)
        {
            if(!MessageHelper.ShowConfirmation("Bạn có chắc chắn muốn mở lại lớp học này không ?"))
            {
                return;
            }

            MessageHelper.ShowSuccess("Chức năng đang được phát triển.");
        }
    }
}