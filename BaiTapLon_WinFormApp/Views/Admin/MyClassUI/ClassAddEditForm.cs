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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon_WinFormApp.Views.Admin.MyClassUI
{
    public partial class ClassAddEditForm : Form
    {
        private readonly ServiceHub _serviceHub;
        private bool isEditMode = false;
        private Class _existingClass = null;

        public ClassAddEditForm(ServiceHub serviceHub, Class update = null)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            isEditMode = update != null;
            _existingClass = update;

            // Đổi title theo mode
            lblTitle.Text = isEditMode ? "Cập nhật lớp học" : "Thêm lớp học mới";
            btnSave.Text = isEditMode ? "Cập nhật" : "Lưu lớp học";

            // Nếu là edit mode, load dữ liệu
            if (isEditMode && _existingClass != null)
            {
                LoadClassData(_existingClass);
            }
        }

        // Load dữ liệu lớp học vào form (cho Edit mode)
        private void LoadClassData(Class classObj)
        {
            txtClassCode.Text = classObj.ClassCode;
            txtClassCode.Enabled = false; // Không cho sửa mã lớp

            txtClassName.Text = classObj.ClassName;
            numMaxStudent.Value = classObj.MaxStudent;
            dtpStartDate.Value = classObj.StartDate.ToDateTime(TimeOnly.MinValue);
            dtpEndDate.Value = classObj.EndDate.ToDateTime(TimeOnly.MinValue);
            cboShift.SelectedIndex = classObj.Shift - 1; // Shift bắt đầu từ 1
            chkStatus.Checked = classObj.Status;
            txtOnlineMeetingLink.Text = classObj.OnlineMeetingLink ?? string.Empty;
            txtNote.Text = classObj.Note ?? string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Confirm trước khi đóng nếu có thay đổi
            var result = MessageBox.Show(
                "Bạn có chắc muốn đóng? Các thay đổi chưa lưu sẽ bị mất.",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra các validation errors trước khi submit
                if (HasValidationErrors())
                {
                    MessageBox.Show(
                        "Vui lòng sửa các lỗi trước khi lưu.",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Validate ngày kết thúc
                if (dtpStartDate.Value >= dtpEndDate.Value)
                {
                    MessageBox.Show(
                        "Ngày bắt đầu phải nhỏ hơn ngày kết thúc.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    dtpEndDate.Focus();
                    return;
                }

                // Kiểm tra thời hạn học
                int months = ((dtpEndDate.Value.Year - dtpStartDate.Value.Year) * 12)
                           + dtpEndDate.Value.Month - dtpStartDate.Value.Month;

                if (months < 4)
                {
                    MessageBox.Show(
                        $"Thời hạn học hiện tại: {months} tháng.\nThời hạn học phải ít nhất 4 tháng.",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    dtpEndDate.Focus();
                    return;
                }

                // Xây dựng object Class từ form
                Class classObj = BuildClass();

                if (classObj == null)
                {
                    return; // Đã có thông báo lỗi trong BuildClass
                }

                string errorMessage;

                if (isEditMode)
                {
                    // Cập nhật lớp học
                    errorMessage = _serviceHub.ClassService.updateClass(classObj);

                    if (errorMessage == null)
                    {
                        MessageBox.Show(
                            $"Cập nhật lớp học '{classObj.ClassName}' thành công!",
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
                            "Lỗi cập nhật",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                else
                {
                    // Tạo lớp học mới
                    errorMessage = _serviceHub.ClassService.createClass(classObj);

                    if (errorMessage == null)
                    {
                        MessageBox.Show(
                            $"Tạo lớp học '{classObj.ClassName}' thành công!",
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
                            "Lỗi tạo lớp học",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Có lỗi xảy ra: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Kiểm tra có lỗi validation nào không
        private bool HasValidationErrors()
        {
            return lblClassCodeError.Visible ||
                   lblClassNameError.Visible ||
                   lblMaxStudentError.Visible ||
                   lblOnlineMeetingLinkError.Visible ||
                   lblNoteError.Visible;
        }

        private Class BuildClass()
        {
            try
            {
                if (isEditMode && _existingClass != null)
                {
                    // Edit mode: Cập nhật object hiện có
                    _existingClass.ClassCode = txtClassCode.Text.Trim();
                    _existingClass.ClassName = txtClassName.Text.Trim();
                    _existingClass.MaxStudent = (int)numMaxStudent.Value;
                    _existingClass.StartDate = DateOnly.FromDateTime(dtpStartDate.Value);
                    _existingClass.EndDate = DateOnly.FromDateTime(dtpEndDate.Value);
                    _existingClass.Shift = cboShift.SelectedIndex + 1; // Shift từ 1-5
                    _existingClass.Status = chkStatus.Checked;
                    _existingClass.OnlineMeetingLink = string.IsNullOrWhiteSpace(txtOnlineMeetingLink.Text)
                        ? null
                        : txtOnlineMeetingLink.Text.Trim();
                    _existingClass.Note = string.IsNullOrWhiteSpace(txtNote.Text)
                        ? null
                        : txtNote.Text.Trim();
                    _existingClass.UpdateAt = DateOnly.FromDateTime(DateTime.Now);

                    return _existingClass;
                }
                else
                {
                    // Create mode: Tạo object mới
                    return new Class
                    {
                        ClassCode = txtClassCode.Text.Trim(),
                        ClassName = txtClassName.Text.Trim(),
                        MaxStudent = (int)numMaxStudent.Value,
                        CurrentStudent = 0, // Mới tạo chưa có học viên
                        StartDate = DateOnly.FromDateTime(dtpStartDate.Value),
                        EndDate = DateOnly.FromDateTime(dtpEndDate.Value),
                        Shift = cboShift.SelectedIndex + 1, // Shift từ 1-5
                        Status = chkStatus.Checked,
                        OnlineMeetingLink = string.IsNullOrWhiteSpace(txtOnlineMeetingLink.Text)
                            ? null
                            : txtOnlineMeetingLink.Text.Trim(),
                        Note = string.IsNullOrWhiteSpace(txtNote.Text)
                            ? null
                            : txtNote.Text.Trim(),
                        CreateAt = DateOnly.FromDateTime(DateTime.Now),
                        UpdateAt = DateOnly.FromDateTime(DateTime.Now)
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi xây dựng dữ liệu lớp học: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }
        }

        // ================== REAL-TIME VALIDATION ==================

        // Validate Mã Lớp
        private void txtClassCode_TextChanged(object sender, EventArgs e)
        {
            string code = txtClassCode.Text.Trim();

            if (string.IsNullOrWhiteSpace(code))
            {
                ShowError(lblClassCodeError, "Mã lớp không được để trống.");
                return;
            }

            if (code.Length > 20)
            {
                ShowError(lblClassCodeError, "Mã lớp không được vượt quá 20 ký tự.");
                return;
            }

            if (!Regex.IsMatch(code, @"^[A-Za-z0-9\-_]+$"))
            {
                ShowError(lblClassCodeError, "Mã lớp chỉ được chứa chữ cái, số, dấu gạch ngang và gạch dưới.");
                return;
            }

            HideError(lblClassCodeError);
        }

        // Validate Tên Lớp
        private void txtClassName_TextChanged(object sender, EventArgs e)
        {
            string name = txtClassName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                ShowError(lblClassNameError, "Tên lớp không được để trống.");
                return;
            }

            if (name.Length < 3)
            {
                ShowError(lblClassNameError, "Tên lớp phải có ít nhất 3 ký tự.");
                return;
            }

            if (name.Length > 255)
            {
                ShowError(lblClassNameError, "Tên lớp không được vượt quá 255 ký tự.");
                return;
            }

            HideError(lblClassNameError);
        }

        // Validate Số Học Viên
        private void numMaxStudent_ValueChanged(object sender, EventArgs e)
        {
            if (numMaxStudent.Value < 5)
            {
                ShowError(lblMaxStudentError, "Số học viên tối đa phải ít nhất 5 người.");
                return;
            }

            if (numMaxStudent.Value > 100)
            {
                ShowError(lblMaxStudentError, "Số học viên tối đa không được vượt quá 100.");
                return;
            }

            HideError(lblMaxStudentError);
        }

        // Validate Link Online
        private void txtOnlineMeetingLink_TextChanged(object sender, EventArgs e)
        {
            string link = txtOnlineMeetingLink.Text.Trim();

            // Nếu trống thì OK (không bắt buộc)
            if (string.IsNullOrWhiteSpace(link))
            {
                HideError(lblOnlineMeetingLinkError);
                return;
            }

            if (link.Length > 500)
            {
                ShowError(lblOnlineMeetingLinkError, "Link không được vượt quá 500 ký tự.");
                return;
            }

            if (!Uri.TryCreate(link, UriKind.Absolute, out Uri uriResult)
                || (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
            {
                ShowError(lblOnlineMeetingLinkError, "Link không hợp lệ. Phải bắt đầu bằng http:// hoặc https://");
                return;
            }

            HideError(lblOnlineMeetingLinkError);
        }

        // Validate Ghi Chú
        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            if (txtNote.Text.Length > 255)
            {
                ShowError(lblNoteError, "Ghi chú không được vượt quá 255 ký tự.");
                return;
            }

            HideError(lblNoteError);
        }

        // Helper methods
        private void ShowError(Label errorLabel, string message)
        {
            errorLabel.Text = "⚠ " + message;
            errorLabel.Visible = true;
        }

        private void HideError(Label errorLabel)
        {
            errorLabel.Visible = false;
        }

        // ================== NAVIGATION ==================

        // Xử lý Enter key để chuyển focus
        private void txtClassCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtClassName.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtClassName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                numMaxStudent.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}