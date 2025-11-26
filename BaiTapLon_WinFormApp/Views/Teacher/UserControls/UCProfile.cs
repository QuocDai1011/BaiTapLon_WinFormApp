using BaiTapLon_WinFormApp.Services;
using CloudinaryDotNet.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon_WinFormApp.Views.Teacher.UserControls
{
    public partial class UCProfile : UserControl
    {
        private readonly int _teacherId;
        private readonly ServiceHub _serviceHub;
        public UCProfile(int teacherId, ServiceHub serviceHub)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _teacherId = teacherId;

            Render();
        }

        private void Render()
        {
            try
            {
                var teacher = _serviceHub.TeacherService.GetTeacherById(_teacherId);
                if (teacher == null)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu giảng viên.");
                    return;
                }
                lblName.Text = teacher.FullName;
                lblName.Location = new Point(
                    (pnTopContent.Width - lblName.Width) / 2 - 50,
                    144
                    );
                txtID.Text = teacher.AdminId + "";
                txtUsername.Text = teacher.UserName;
                txtFullName.Text = teacher.FullName;
                txtEmail.Text = teacher.Email;
                if (teacher.Gender)
                {
                    txtGender.Text = "Nam";
                }
                else
                {
                    txtGender.Text = "Nữ";
                }
                txtDateOfBirth.Text = teacher.DateOfBirth + "";
                txtPhoneNumber.Text = teacher.PhoneNumber;
                txtAddress.Text = teacher.Address;
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblNameProfile_Click(object sender, EventArgs e)
        {

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đang trong quá trình phát triển! Vui lòng chờ đợi phiên bản tiếp theo.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var teacher = _serviceHub.TeacherService.GetTeacherById(_teacherId);
            if (teacher == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu giảng viên.");
                return;
            }
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                return;
            }
            else
            {
                teacher.FullName = txtFullName.Text;
            }

            if (txtGender.Text != "Nam" && txtGender.Text != "Nữ")
            {
                MessageBox.Show("Giới tính chỉ được nhập: 'Nam' hoặc 'Nữ'");
                return;
            }
            else if (txtGender.Text.Equals("Nam"))
            {
                teacher.Gender = true;
            }
            else
            {
                teacher.Gender = false;
            }

            if (!DateOnly.TryParse(txtDateOfBirth.Text, out DateOnly dob))
            {
                MessageBox.Show("Ngày sinh không hợp lệ. Vui lòng nhập theo dạng yyyy-MM-dd hoặc dd/MM/yyyy.");
                return;
            }

            if (dob >= DateOnly.FromDateTime(DateTime.Now))
            {
                MessageBox.Show("Ngày sinh phải nhỏ hơn ngày hiện tại.");
                return;
            }

            teacher.DateOfBirth = dob;

            if (txtPhoneNumber.Text.Count() != 10)
            {
                MessageBox.Show("Số điện thoại phải đủ 10 chữ số.");
                return;
            }
            else
            {
                if (!txtPhoneNumber.Text.StartsWith('0'))
                {
                    MessageBox.Show("Số điện thoại phải bắt đầu bằng chữ số '0'.");
                    return;
                }
                teacher.PhoneNumber = txtPhoneNumber.Text;
            }

            teacher.Address = txtAddress.Text;

            int success = _serviceHub.TeacherService.UpdateProfile(_teacherId, teacher);
            if (success == 0)
            {
                MessageBox.Show(
                    "Cập nhật thất bại.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            else
            {
                MessageBox.Show(
                    "Cập nhật thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                //Render();
                ReloadFormUI();
            }
        }

        public void ReloadFormUI()
        {
            var parent = this.FindForm() as TeacherMainForm;
            parent?.SetTeacherName();
        }

        private void pnTopContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnBottomContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
