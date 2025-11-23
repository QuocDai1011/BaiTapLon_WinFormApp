// ===============================================
// CODE SỬA LỖI CHO CourseAddEditForm.cs
// ===============================================
using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Services;
using BaiTapLon_WinFormApp.Utils;
using System;
using System.Windows.Forms;

namespace BaiTapLon_WinFormApp.Views.Admin.CourseUI
{
    public partial class CourseAddEditForm : Form
    {
        private readonly ServiceHub _serviceHub;
        private Course _course;
        private bool _isEditMode = false;

        public CourseAddEditForm(ServiceHub serviceHub, Course course = null)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _course = course;
            _isEditMode = course != null;
            initCombobox();

            // Nếu là edit mode, load dữ liệu vào form
            if (_isEditMode)
            {
                LoadCourseData();
            }
        }

        private void initCombobox()
        {
            cboLevel.Items.AddRange(new string[] { "A1", "A2", "B1", "B2", "C1", "C2" });
            cboLevel.SelectedIndex = 0; // Chọn mặc định
        }

        // Load dữ liệu course vào form khi edit
        private void LoadCourseData()
        {
            if (_course != null)
            {
                txtCourseCode.Text = _course.CourseCode;
                txtCourseName.Text = _course.CourseName;
                numTutitionFee.Value = Decimal.Round(_course.TutitionFee, 3);
                numNumberSession.Value = _course.NumberSessions;
                txtDescription.Text = _course.Description;
                cboLevel.Text = _course.Level;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate dữ liệu trước khi lưu
                if (!ValidateInput())
                    return;

                Course course = builderCourse();

                if (_isEditMode)
                    UpdateCourse(course);
                else
                    AddCourse(course);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(
                    $"❌ Đã xảy ra lỗi khi {(_isEditMode ? "cập nhật" : "tạo")} khóa học!\n{ex.Message}");
            }
        }

        // ⭐ VALIDATE INPUT
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCourseCode.Text))
            {
                MessageHelper.ShowWarning("⚠️ Vui lòng nhập mã khóa học!");
                txtCourseCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageHelper.ShowWarning("⚠️ Vui lòng nhập tên khóa học!");
                txtCourseName.Focus();
                return false;
            }

            if (numTutitionFee.Value <= 0)
            {
                MessageHelper.ShowWarning("⚠️ Học phí phải lớn hơn 0!");
                numTutitionFee.Focus();
                return false;
            }

            if (numNumberSession.Value <= 0)
            {
                MessageHelper.ShowWarning("⚠️ Số buổi học phải lớn hơn 0!");
                numNumberSession.Focus();
                return false;
            }

            if (cboLevel.SelectedIndex < 0)
            {
                MessageHelper.ShowWarning("⚠️ Vui lòng chọn trình độ!");
                cboLevel.Focus();
                return false;
            }

            return true;
        }

        // ⭐ SỬA LỖI: THÊM KHÓA HỌC
        private void AddCourse(Course course)
        {
            try
            {
                string message = _serviceHub.CourseService.createCourse(course);

                // ❌ LỖI Ở ĐÂY: Kiểm tra sai logic
                if (!string.IsNullOrEmpty(message))
                {
                    // Nếu có message = CÓ LỖI
                    MessageHelper.ShowError($"Đã có lỗi xảy ra!\n{message}");
                    return; // ⭐ THÊM RETURN để dừng lại, không hiện "thành công"
                }

                // Chỉ hiện thông báo thành công khi KHÔNG có lỗi
                MessageHelper.ShowSuccess("Đã thêm khóa học thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"❌ Lỗi: {ex.Message}");
            }
        }

        // ⭐ SỬA LỖI: CẬP NHẬT KHÓA HỌC
        private void UpdateCourse(Course course)
        {
            try
            {
                string message = _serviceHub.CourseService.updateCourse(course);

                // ❌ LỖI Ở ĐÂY: Kiểm tra sai logic
                if (!string.IsNullOrEmpty(message))
                {
                    // Nếu có message = CÓ LỖI
                    MessageHelper.ShowError($"Đã có lỗi xảy ra!\n{message}");
                    return; // ⭐ THÊM RETURN để dừng lại
                }

                // Chỉ hiện thông báo thành công khi KHÔNG có lỗi
                MessageHelper.ShowSuccess("Đã cập nhật khóa học thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError($"Lỗi: {ex.Message}");
            }
        }

        private Course builderCourse()
        {
            DateTime today = DateTime.Now;

            if (_isEditMode)
            {
                _course.CourseCode = txtCourseCode.Text.Trim();
                _course.CourseName = txtCourseName.Text.Trim();
                _course.TutitionFee = Decimal.Round(numTutitionFee.Value, 3);
                _course.NumberSessions = (int)numNumberSession.Value;
                _course.Description = txtDescription.Text.Trim();
                _course.Level = cboLevel.Text;
                _course.UpdateAt = today;
                _course.AvatarLink = "https://example.com/images/business_eng.png";
                return _course;
            }

            return new Course
            {
                CourseCode = txtCourseCode.Text.Trim(),
                CourseName = txtCourseName.Text.Trim(),
                TutitionFee = Decimal.Round(numTutitionFee.Value, 3),
                NumberSessions = (int)numNumberSession.Value,
                Description = txtDescription.Text.Trim(),
                Level = cboLevel.Text,
                CreateAt = today,
                UpdateAt = today,
                AvatarLink = "https://example.com/images/business_eng.png"
            };
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
