using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Services;
using BaiTapLon_WinFormApp.Utils;

namespace BaiTapLon_WinFormApp.Views.Admin.StudentUI
{
    public partial class StudentAddEditForm : Form
    {
        // ==================== FIELDS ====================
        private readonly ServiceHub _service;
        private readonly Student _student;
        private bool _isEditMode = false;

        // ==================== CONSTRUCTOR ====================
        public StudentAddEditForm(ServiceHub service, Student student = null)
        {
            InitializeComponent();
            InitializeForm();

            _service = service;
            _student = student;                // gán Student đúng kiểu
            _isEditMode = student != null;     // kiểm tra chế độ edit hay add

            if (_isEditMode)
                LoadStudentData();
        }

        // ==================== FORM INITIALIZATION ====================
        private void InitializeForm()
        {
            try
            {
                SetupEventHandlers();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khởi tạo form:\n{ex.Message}");
                this.Close();
            }
        }

        private void SetupEventHandlers()
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        // ==================== LOAD DATA ====================
        private void LoadStudentData()
        {
            txtUserName.Text = _student.UserName;
            txtPassword.Text = _student.Password;
            txtFullName.Text = _student.FullName;
            txtEmail.Text = _student.Email;
            txtPhone.Text = _student.PhoneNumber;
            txtPhoneParents.Text = _student.PhoneNumberOfParents;
            txtAddress.Text = _student.Address;

            cboGender.SelectedItem = _student.Gender ? "Nam" : "Nữ";

            if (_student.DateOfBirth != null)
                dtpDateOfBirth.Text = _student.DateOfBirth.ToString();

            chkIsActive.Checked = _student.IsActive;
        }

        // ==================== BUTTON EVENTS ====================
        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Build Student object
                Student student = BuildStudentFromForm();

                // Validate
                var errors = Validator.ValidateStudent(student);
                if (errors.Any())
                {
                    MessageHelper.ShowError(string.Join("\n", errors));
                    return;
                }

                if (_isEditMode)
                    UpdateStudent(student);
                else
                    AddStudent(student);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi không mong muốn:\n{ex.Message}\n\nChi tiết: {ex.InnerException?.Message}");
            }
        }


        // ==================== CRUD METHODS ====================
        private void AddStudent(Student student)
        {
            try
            {
                string result = _service.StudentService.createStudent(student);
                if (!string.IsNullOrEmpty(result))
                {
                    MessageHelper.ShowError($"Lỗi khi thêm sinh viên:\n{result}");
                    return;
                }

                MessageHelper.ShowInfo("Thêm sinh viên thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khi thêm sinh viên:\n{ex.Message}");
                return;
            }
        }

        private void UpdateStudent(Student student)
        {
            try
            {
                string result = _service.StudentService.updateStudent(student);
                if (!string.IsNullOrEmpty(result))
                {
                    MessageHelper.ShowError($"Lỗi khi cập nhật sinh viên:\n{result}");
                    return;
                }

                MessageHelper.ShowInfo("Cập nhật sinh viên thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi khi cập nhật sinh viên:\n{ex.Message}");
            }
        }

        // ==================== VALIDATION ====================
        

        // ==================== BUILD STUDENT OBJECT ====================
        private Student BuildStudentFromForm()
        {
            DateOnly now = DateOnly.MaxValue;
            bool gender = cboGender.SelectedItem?.ToString() == "Nam";

            if (_isEditMode)
            {
                _student.UserName = txtUserName.Text.Trim();
                _student.Password = txtPassword.Text.Trim();
                _student.FullName = txtFullName.Text.Trim();
                _student.Email = txtEmail.Text.Trim();
                _student.PhoneNumber = txtPhone.Text.Trim();
                _student.PhoneNumberOfParents = txtPhoneParents.Text.Trim();
                _student.Gender = gender;
                _student.Address = txtAddress.Text.Trim();
                _student.DateOfBirth = DateOnly.FromDateTime(dtpDateOfBirth.Value);
                _student.UpdateAt = now;
                _student.IsActive = chkIsActive.Checked;
                return _student;
            }

            return new Student
            {
                UserName = txtUserName.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                PhoneNumberOfParents = txtPhoneParents.Text.Trim(),
                Gender = gender,
                Address = txtAddress.Text.Trim(),
                DateOfBirth = DateOnly.FromDateTime(dtpDateOfBirth.Value),
                CreatAt = now,
                UpdateAt = now,
                IsActive = chkIsActive.Checked
            };
        }
    }
}
