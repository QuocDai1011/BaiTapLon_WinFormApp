using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Services;
using BaiTapLon_WinFormApp.Utils;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace BaiTapLon_WinFormApp.Views.Admin.StudentUI
{
    public partial class ManageStudent : UserControl
    {
        private readonly ServiceHub _service;
        private List<Student> _student;

        public ManageStudent(ServiceHub serviceHub)
        {
            InitializeComponent();
            _service = serviceHub;
            LoadStudentsAsync();
        }
        
        private void LoadStudentsAsync()
        {
            try
            {
                _student = _service.StudentService.getAllStudent().ToList();

                if (_student == null)
                {
                    throw new Exception("Danh sách sinh viên trống.");
                }

                lblTotalStudents.Text = "Tổng số " + _student.Count.ToString() + " sinh viên";

                DisplayStudents(_student);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi tải danh sách sinh viên:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void DisplayStudents(List<Student> students)
        {
            dgvStudents.Rows.Clear();
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

            // Header căn giữa
            foreach (DataGridViewColumn col in dgvStudents.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            var studentForm = new StudentAddEditForm(_service);
            var result = studentForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadStudentsAsync();
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStudentsAsync();
        }

        private void btnEdit_click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng!");
                return;
            }
            DataGridViewRow selectedStudent = dgvStudents.CurrentRow;

            Student? s = _service.StudentService.GetStudentById((int)selectedStudent.Cells["colId"].Value);

            var studentForm = new StudentAddEditForm(_service, s);

            var result = studentForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadStudentsAsync();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có chọn dòng không
            if (dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng!");
                return;
            }

            // Xác nhận xóa chung
            if (!MessageHelper.ShowConfirmation("Bạn có chắc chắn muốn xóa sinh viên này không?"))
                return;

            int studentId = (int)dgvStudents.CurrentRow.Cells["colId"].Value;

            // Kiểm tra sinh viên đang học lớp nào
            List<Class> studentInClass = _service.ClassService.StudentInClassByStudentId(studentId).ToList();

            if (studentInClass.Count > 0)
            {
                string classes = string.Join("\n", studentInClass.Select(c => c.ClassName));
                bool confirm = MessageHelper.ShowConfirmation(
                    $"Sinh viên đang học tại lớp:\n{classes}\nViệc xóa sinh viên này sẽ đồng thời xóa sinh viên tại lớp học đó!");
                if (!confirm)
                    return; // Dừng nếu người dùng không đồng ý
            }

            try
            {
                Student? s = _service.StudentService.GetStudentById(studentId);
                if (s == null)
                {
                    MessageHelper.ShowError("Sinh viên không tồn tại!");
                    return;
                }

                // xóa sinh viên
                _service.StudentService.deleteStudent(s.StudentId);
                // xóa sinh viên khỏi các lớp học
                foreach (Class c in studentInClass)
                {
                    _service.ClassService.removeStudentFromClass(c.ClassId, s.StudentId);
                }
                MessageHelper.ShowSuccess("Xóa sinh viên thành công!");
                LoadStudentsAsync();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Lỗi khi xóa sinh viên:\n" + ex.Message);
            }
        }

        private void btnAddByExcel_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                openFileDialog.Title = "Chọn file Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;

                        // Đọc và import
                        var result = ImportStudentsFromExcel(openFileDialog.FileName);

                        // Hiển thị kết quả cho người dùng
                        if (result.errors.Any())
                        {
                            var sb = new StringBuilder();
                            sb.AppendLine($"Nhập thành công: {result.successCount}");
                            sb.AppendLine($"Nhập thất bại: {result.errors.Count}");
                            sb.AppendLine();
                            sb.AppendLine("Chi tiết lỗi:");
                            foreach (var err in result.errors)
                            {
                                sb.AppendLine(err);
                            }

                            MessageHelper.ShowError(sb.ToString(), "Kết quả nhập Excel");
                        }
                        else
                        {
                            MessageHelper.ShowSuccess($"Nhập dữ liệu thành công! Số bản ghi: {result.successCount}");
                        }

                        LoadStudentsAsync(); // Refresh lại DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageHelper.ShowError($"Lỗi: {ex.Message}");
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
        }

        // ===============================================
        // ĐỌC FILE EXCEL VÀ THÊM VÀO DATABASE
        // Trả về tuple: successCount và danh sách lỗi
        // ===============================================
        private (int successCount, List<string> errors) ImportStudentsFromExcel(string filePath)
        {
            var errors = new List<string>();
            int successCount = 0;

            // License must be set once at application startup (Program.cs).
            // Do not use the deprecated LicenseContext API from older EPPlus versions.

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0]; // Sheet đầu tiên
                int rowCount = worksheet.Dimension.Rows;

                // Đọc từ dòng 2 (dòng 1 là header)
                for (int row = 2; row <= rowCount; row++)
                {
                    // Bỏ qua dòng trống
                    if (string.IsNullOrWhiteSpace(worksheet.Cells[row, 1].Text))
                        continue;

                    // Tạo object Student
                    var student = new Student
                    {
                        UserName = worksheet.Cells[row, 1].Text.Trim(),
                        Password = worksheet.Cells[row, 2].Text.Trim(),
                        FullName = worksheet.Cells[row, 3].Text.Trim(),
                        Email = worksheet.Cells[row, 4].Text.Trim(),
                        Gender = worksheet.Cells[row, 5].Text.Trim().ToLower() == "nam",
                        Address = worksheet.Cells[row, 6].Text.Trim(),
                        DateOfBirth = ParseDate(worksheet.Cells[row, 7].Text),
                        PhoneNumber = worksheet.Cells[row, 8].Text.Trim(),
                        PhoneNumberOfParents = worksheet.Cells[row, 9].Text.Trim(),
                        CreatAt = DateOnly.FromDateTime(DateTime.Now),
                        UpdateAt = DateOnly.FromDateTime(DateTime.Now),
                        IsActive = worksheet.Cells[row, 10].Text.Trim() == "1"
                    };

                    MessageHelper.ShowInfo("Thông tin:" + student);

                    // Thêm vào database
                    string message = _service.StudentService.createStudent(student);

                    if (!string.IsNullOrEmpty(message))
                    {
                        errors.Add($"Dòng {row}: {message}");
                    }
                    else
                    {
                        successCount++;
                    }
                }
            }

            return (successCount, errors);
        }

        // Parse ngày tháng
        private DateOnly? ParseDate(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            if (DateTime.TryParse(value, out var date))
                return DateOnly.FromDateTime(date);
            return null;
        }
    }
}
