using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Services;
using BaiTapLon_WinFormApp.Services.Implementations;
using BaiTapLon_WinFormApp.Utils;
using BaiTapLon_WinFormApp.Views.Admin.HomePageUI;
using BaiTapLon_WinFormApp.Views.SystemAcess.Pages.ForgetForm;
using BaiTapLon_WinFormApp.Views.Teacher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Validator = BaiTapLon_WinFormApp.Utils.Validator;

namespace BaiTapLon_WinFormApp.Views.SystemAcess.Login
{
    public partial class LoginForm : Form
    {
        private readonly string _connectionString;
        private readonly ServiceHub _serviceHub;
        public LoginForm(ServiceHub serviceHub)
        {
            _serviceHub = serviceHub;
            InitializeComponent();
        }
        private (bool isSucces, string? userRole) CheckLogin(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập email và mật khẩu!");
                return (false, null);
            }
            string userRole;
            var isLogin = _serviceHub.AuthService.Login(email, password, out userRole);

            if (isLogin == false)
            {
                MessageBox.Show("Email không tồn tại trong hệ thống hoặc sai mật khẩu!");
                return (false, null);
            }
            else
            {
                MessageBox.Show($"Đăng nhập thành công!");
                return (true, userRole);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbEmailLogin.Text.Trim();
            string password = txbPassLogin.Text.Trim();
            var check = CheckLogin(username, password);
            if (check.isSucces)
            {
                switch (check.userRole)
                {
                    case "admins":
                        {
                            var admin = _serviceHub.AdminService.getAdminByEmail(username);
                            if (admin == null)
                            {
                                MessageHelper.ShowError($"Đã có lỗi khi lấy thông tin giảng viên \n có email {username}");
                                return;
                            }
                            new HomePage(_serviceHub, username).ShowDialog();
                            this.Close();
                            break;
                        }
                    case "teachers":
                        {
                            var teacher = _serviceHub.TeacherService.getTeacherByEmai(username);
                            if(teacher == null)
                            {
                                MessageHelper.ShowError($"Đã có lỗi khi lấy thông tin giảng viên \n có email {username}");
                                return;
                            }
                            new TeacherMainForm(_serviceHub, teacher.AdminId).ShowDialog();
                            this.Close();
                            break;
                        }
                    case "students":
                        {
                            var teacher = _serviceHub.TeacherService.getTeacherByEmai(username);
                            if (teacher == null)
                            {
                                MessageHelper.ShowError($"Đã có lỗi khi lấy thông tin giảng viên \n có email {username}");
                                return;
                            }
                            new TeacherMainForm(_serviceHub, teacher.AdminId).ShowDialog();
                            this.Close();
                            break;
                        }
                }
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

            pnBackgroundLogin.Visible = false;
            pnBackgroundRegister.Visible = true;
            txbEmailLogin.Text = "";
            txbPassLogin.Text = "";
        }
        private void lblNavigationLogin_Click(object sender, EventArgs e)
        {
            pnBackgroundRegister.Visible = false;
            pnBackgroundLogin.Visible = true;
        }
        private void lblNavigationRegister_Click(object sender, EventArgs e)
        {
            pnBackgroundRegister.Visible = true;
            pnBackgroundLogin.Visible = false;
        }
        private void clearRegisterForm()
        {
            txbHoRegister.Text = "";
            txbTenRegister.Text = "";
            txbUsernameRegister.Text = "";
            txbPassRegister.Text = "";
            txbConfirmPass.Text = "";
            txbDiaChi.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            cbxGioiTinh.SelectedIndex = -1;
            txbSdt.Text = "";
            txbSdtPhuHuynh.Text = "";
        }
        private void txbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txbUsernameRegister.Text.Trim();
            string password = txbPassRegister.Text.Trim();
            string firstName = txbHoRegister.Text.Trim();
            string lastName = txbTenRegister.Text.Trim();
            string confirmPassword = txbConfirmPass.Text.Trim();
            string address = txbDiaChi.Text.Trim();
            DateTime dob = dtpNgaySinh.Value;
            bool gender;
            if (cbxGioiTinh.Text.Trim() == "Nam") gender = true;
            else gender = false;
            string phone = txbSdt.Text.Trim();
            string parentPhone = txbSdtPhuHuynh.Text.Trim();
            bool check = RegisterUser(firstName, lastName, username, password, confirmPassword, address, dob, gender, phone, parentPhone);
            if (check == true)
            {
                pnBackgroundRegister.Visible = false;
                pnBackgroundLogin.Visible = true;
            }

        }
        private bool checkRegisterForm(
            string firstName,
            string lastName,
            string email,
            string password,
            string confirmPassword,
            string address,
            DateTime dob,
            bool gender,
            string phone,
            string parentPhone)
        {
            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc!");
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address != email)
                {
                    MessageBox.Show("Email không hợp lệ!");
                    return false;
                }
                if (Validator.IsValidEmail(email) == false)
                {
                    MessageBox.Show("Email không hợp lệ, phải đúng định dạng example@domain.com!");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Email không hợp lệ!");
                return false;
            }
            if (Validator.IsStrongPassword(password) == false)
            {
                MessageBox.Show("Mật khẩu đăng kí không đủ mạnh! Vui lòng đảm bảo mật khẩu có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt.");
                return false;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp!");
                return false;
            }
            if (password.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải từ 6 ký tự trở lên!");
                return false;
            }
            if (Validator.IsValidPhone(phone) == false)
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập đúng định dạng số điện thoại Việt Nam.");
                return false;
            }

            if (Validator.IsValidPhone(parentPhone) == false)
            {
                MessageBox.Show("Số điện thoại bố mẹ không hợp lệ! Vui lòng nhập đúng định dạng số điện thoại Việt Nam.");
                return false;
            }
            if (Validator.IsValidAge(DateTime.Now.Year - dob.Year) == false)
            {
                MessageBox.Show("Yêu cầu học viên trên 4 tuổi.");
                return false;
            }
            return true;
        }
        private bool RegisterUser(
            string firstName,
            string lastName,
            string email,
            string password,
            string confirmPassword,
            string address,
            DateTime dob,
            bool gender,
            string phone,
            string parentPhone)
        {
            if (!checkRegisterForm(firstName, lastName, email, password, confirmPassword, address, dob, gender, phone, parentPhone))
            {
                return false;
            }
            bool isRegistered = _serviceHub.AuthService.RegisterStudent(
              firstName, lastName, email, password, address, dob, gender, phone, parentPhone);
            if (!isRegistered)
            {
                MessageBox.Show("Đăng ký thất bại!");
                return false;
            }
            else MessageBox.Show("Đăng ký thành công!");
            clearRegisterForm();
            return true;
        }

        private void lblForgetPass_Click(object sender, EventArgs e)
        {
            try
            {
                var forgetForm = new ForgetForm(_serviceHub);
                forgetForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi mở form quên mật khẩu: " + ex.Message);
            }
        }
        private void CenterLoginPanel()
        {
            if (guna2Panel6 == null || guna2Panel3 == null || this == null) return;

            // Căn ngang + dọc
            guna2Panel6.Left = (this.ClientSize.Width - guna2Panel6.Width) / 2;
            guna2Panel6.Top = (this.ClientSize.Height - guna2Panel6.Height) / 2;
            guna2Panel3.Left = (this.ClientSize.Width - guna2Panel3.Width) / 2;
            guna2Panel3.Top = (this.ClientSize.Height - guna2Panel3.Height) / 2;
            // Khi form resize, tự động căn lại
            this.Resize -= Form_Resize;
            this.Resize += Form_Resize;

            void Form_Resize(object sender, EventArgs e)
            {
                // Phải dùng cùng panel, không dùng pnBackgroundLogin
                guna2Panel6.Left = (this.ClientSize.Width - guna2Panel6.Width) / 2;
                guna2Panel6.Top = (this.ClientSize.Height - guna2Panel6.Height) / 2;
                guna2Panel3.Left = (this.ClientSize.Width - guna2Panel3.Width) / 2;
                guna2Panel3.Top = (this.ClientSize.Height - guna2Panel3.Height) / 2;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            CenterLoginPanel();
        }
    }
}
