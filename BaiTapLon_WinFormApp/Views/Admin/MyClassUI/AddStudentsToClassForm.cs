using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BaiTapLon_WinFormApp.Views.Admin.MyClassUI
{
    public partial class AddStudentsToClassForm : Form
    {
        private readonly ServiceHub _serviceHub;
        private readonly Class _class;
        private List<Student> _allStudents;
        private List<Student> _filteredStudents;

        public List<Student> SelectedStudents { get; private set; }
        private List<Student> _studentInClasses;
        public AddStudentsToClassForm(ServiceHub serviceHub, Class classObj, List<Student> studentInClasses)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _class = classObj;
            SelectedStudents = new List<Student>();

            _studentInClasses = studentInClasses;
            LoadStudents();
        }

        // Load danh sách học viên chưa có trong lớp
        private void LoadStudents()
        {
            try
            {
                // Lấy tất cả học viên
                _allStudents = _serviceHub.StudentService.getAllStudent();

                // Lấy danh sách StudentId của học viên đã có trong lớp
                var studentsInClassIds = _studentInClasses.Select(s => s.StudentId).ToHashSet();
                // Lọc bỏ những học viên đã có trong lớp
                _allStudents = _allStudents
                    .Where(s => !studentsInClassIds.Contains(s.StudentId))
                    .ToList();

                _filteredStudents = _allStudents;

                // Cập nhật title với số lượng
                lblTitle.Text = $"Thêm Học Viên Vào Lớp ({_allStudents.Count} học viên khả dụng)";

                PopulateCheckedListBox(_filteredStudents);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi tải danh sách học viên: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Hiển thị danh sách học viên vào CheckedListBox
        private void PopulateCheckedListBox(List<Student> students)
        {
            clbStudents.Items.Clear();

            foreach (var student in students)
            {
                // Hiển thị: "MSSV - Họ và tên"
                string displayText = $"{student.StudentId}  -  {student.FullName}";
                clbStudents.Items.Add(new StudentItem(student, displayText));
            }

            UpdateSelectedCount();
        }

        // Class wrapper để lưu Student object trong CheckedListBox
        private class StudentItem
        {
            public Student Student { get; set; }
            public string DisplayText { get; set; }

            public StudentItem(Student student, string displayText)
            {
                Student = student;
                DisplayText = displayText;
            }

            public override string ToString()
            {
                return DisplayText;
            }
        }

        // Tìm kiếm học viên
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // Nếu search box trống, hiện tất cả
                _filteredStudents = new List<Student>(_allStudents);
            }
            else
            {
                // Tìm theo ID hoặc tên
                _filteredStudents = _allStudents
                    .Where(s =>
                        s.StudentId.ToString().Contains(searchText) ||
                        s.FullName.ToLower().Contains(searchText)
                    )
                    .ToList();
            }

            PopulateCheckedListBox(_filteredStudents);

            // Thông báo nếu không tìm thấy
            if (_filteredStudents.Count == 0)
            {
                MessageBox.Show(
                    "Không tìm thấy học viên phù hợp.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        // Chọn/bỏ chọn tất cả
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbStudents.Items.Count; i++)
            {
                clbStudents.SetItemChecked(i, chkSelectAll.Checked);
            }
        }

        // Cập nhật số lượng đã chọn
        private void clbStudents_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Dùng BeginInvoke vì ItemCheck event trigger trước khi item thực sự được check
            this.BeginInvoke(new Action(() => UpdateSelectedCount()));
        }

        private void UpdateSelectedCount()
        {
            int count = clbStudents.CheckedItems.Count;
            lblSelectedCount.Text = $"Đã chọn: {count} học viên";

            // Cập nhật checkbox "Chọn tất cả"
            if (count == 0)
            {
                chkSelectAll.CheckState = CheckState.Unchecked;
            }
            else if (count == clbStudents.Items.Count)
            {
                chkSelectAll.CheckState = CheckState.Checked;
            }
            else
            {
                chkSelectAll.CheckState = CheckState.Indeterminate;
            }
        }

        // Thêm học viên vào lớp
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (clbStudents.CheckedItems.Count == 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn ít nhất một học viên.",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Kiểm tra số lượng có vượt quá không
            int availableSlots = _class.MaxStudent - _studentInClasses.Count;
            if (clbStudents.CheckedItems.Count > availableSlots)
            {
                MessageBox.Show(
                    $"Lớp chỉ còn {availableSlots} chỗ trống.\n" +
                    $"Bạn đang chọn {clbStudents.CheckedItems.Count} học viên.",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Confirm
            var result = MessageBox.Show(
                $"Bạn có chắc muốn thêm {clbStudents.CheckedItems.Count} học viên vào lớp '{_class.ClassName}'?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Lấy danh sách học viên đã chọn
                SelectedStudents = clbStudents.CheckedItems
                    .Cast<StudentItem>()
                    .Select(item => item.Student)
                    .ToList();

                try
                {
                    // Thêm học viên vào lớp (gọi service 1 lần với danh sách)
                    string errorMessage = _serviceHub.ClassService.addStudentsToClass(
                        _class.ClassId,
                        SelectedStudents.Select(s => s.StudentId).ToList()
                    );

                    if (errorMessage == null)
                    {
                        MessageBox.Show(
                            $"Đã thêm {SelectedStudents.Count} học viên vào lớp thành công!",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(
                            errorMessage,
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Lỗi khi thêm học viên: {ex.Message}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Hỗ trợ tìm kiếm bằng Enter key
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && txtSearch.Focused)
            {
                btnSearch_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}