using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon_WinFormApp.Views.Admin.ProfileUI
{
    public partial class UserProfile : UserControl
    {
        private readonly ServiceHub _serviceHub;
        private readonly int _id;

        private bool isEditMode = false;
        private bool isDarkMode = false;
        private Color lightBackgroundColor = Color.FromArgb(245, 245, 245);
        private Color darkBackgroundColor = Color.FromArgb(33, 33, 33);
        private Color lightPanelColor = Color.White;
        private Color darkPanelColor = Color.FromArgb(48, 48, 48);
        private Color lightTextColor = Color.FromArgb(66, 66, 66);
        private Color darkTextColor = Color.FromArgb(220, 220, 220);
        public UserProfile(ServiceHub serviceHub, int id)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _id = id;
            LoadSampleData();
            InitializeSettings();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            isEditMode = true;
            EnableEditMode(true);
            btnEdit.Visible = false;
            btnSave.Visible = true;
        }

        // Xử lý nút Lưu
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                isEditMode = false;
                EnableEditMode(false);
                btnEdit.Visible = true;
                btnSave.Visible = false;

                lblUserName.Text = txtFullName.Text;
                UpdateAvatar();

                MessageBox.Show("Đã lưu thông tin thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                OnProfileUpdated(EventArgs.Empty);
            }
        }

        // Xử lý nút Đổi mật khẩu
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đổi mật khẩu sẽ được hiển thị ở đây.\n\n" +
                          "Bạn có thể tạo một Form hoặc Dialog riêng để xử lý việc đổi mật khẩu.",
                          "Đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OnChangePasswordRequested(EventArgs.Empty);
        }

        // Xử lý nút Đổi ảnh
        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Chọn ảnh đại diện";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image img = Image.FromFile(openFileDialog.FileName);
                        pictureBoxAvatar.Image = img;

                        MessageBox.Show("Đã cập nhật ảnh đại diện!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        OnAvatarChanged(EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải ảnh: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Xử lý toggle Dark Mode
        private void toggleDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            isDarkMode = toggleDarkMode.Checked;
            ApplyTheme();

            toggleDarkMode.Text = isDarkMode ? "🌙 Chế độ tối" : "☀️ Chế độ sáng";
            toggleDarkMode.ForeColor = isDarkMode ? Color.White : Color.Black;

            OnThemeChanged(new ThemeChangedEventArgs(isDarkMode));
        }

        // Áp dụng theme
        private void ApplyTheme()
        {
            Color bgColor = isDarkMode ? darkBackgroundColor : lightBackgroundColor;
            Color panelColor = isDarkMode ? darkPanelColor : lightPanelColor;
            Color textColor = isDarkMode ? darkTextColor : lightTextColor;
            Color inputBgColor = isDarkMode ? Color.FromArgb(60, 60, 60) : Color.WhiteSmoke;

            // Main panel
            panelMain.BackColor = bgColor;

            // Header và Content panels
            panelHeader.BackColor = panelColor;
            panelProfile.BackColor = panelColor;
            panelSettings.BackColor = panelColor;

            // Sub panels
            panelTheme.BackColor = isDarkMode ? Color.FromArgb(55, 55, 55) : Color.FromArgb(250, 250, 250);
            panelLanguage.BackColor = isDarkMode ? Color.FromArgb(55, 55, 55) : Color.FromArgb(250, 250, 250);

            // Labels
            lblUserName.ForeColor = isDarkMode ? Color.White : Color.FromArgb(33, 150, 243);
            lblRole.ForeColor = isDarkMode ? Color.LightGray : Color.Gray;
            lblProfileTitle.ForeColor = isDarkMode ? Color.White : Color.FromArgb(33, 150, 243);
            lblSettingsTitle.ForeColor = isDarkMode ? Color.White : Color.FromArgb(33, 150, 243);

            lblFullName.ForeColor = textColor;
            lblBirthday.ForeColor = textColor;
            lblAddress.ForeColor = textColor;
            lblPhone.ForeColor = textColor;
            lblEmail.ForeColor = textColor;
            lblTheme.ForeColor = textColor;
            lblLanguage.ForeColor = textColor;

            // TextBoxes
            txtFullName.BackColor = inputBgColor;
            txtFullName.ForeColor = textColor;
            txtAddress.BackColor = inputBgColor;
            txtAddress.ForeColor = textColor;
            txtPhone.BackColor = inputBgColor;
            txtPhone.ForeColor = textColor;
            txtEmail.BackColor = inputBgColor;
            txtEmail.ForeColor = textColor;

            // DateTimePicker
            dateTimePickerBirthday.BackColor = inputBgColor;
            dateTimePickerBirthday.ForeColor = textColor;

            // ComboBox
            cboLanguage.BackColor = inputBgColor;
            cboLanguage.ForeColor = textColor;
        }

        // Xử lý thay đổi ngôn ngữ
        private void cboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLanguage = cboLanguage.SelectedItem.ToString();

            MessageBox.Show($"Đã chuyển sang: {selectedLanguage}\n\n" +
                          "Bạn có thể implement logic đa ngôn ngữ ở đây.",
                          "Thay đổi ngôn ngữ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OnLanguageChanged(new LanguageChangedEventArgs(selectedLanguage));
        }

        // Xử lý nút Đăng xuất
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                OnLogoutRequested(EventArgs.Empty);
            }
        }

        // Bật/tắt chế độ chỉnh sửa
        private void EnableEditMode(bool enable)
        {
            txtFullName.ReadOnly = !enable;
            txtAddress.ReadOnly = !enable;
            txtPhone.ReadOnly = !enable;
            txtEmail.ReadOnly = !enable;
            dateTimePickerBirthday.Enabled = enable;

            Color bgColor;
            if (isDarkMode)
            {
                bgColor = enable ? Color.FromArgb(60, 60, 60) : Color.FromArgb(60, 60, 60);
            }
            else
            {
                bgColor = enable ? Color.White : Color.WhiteSmoke;
            }

            txtFullName.BackColor = bgColor;
            txtAddress.BackColor = bgColor;
            txtPhone.BackColor = bgColor;
            txtEmail.BackColor = bgColor;
        }

        // Validate dữ liệu
        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        // Events
        public event EventHandler ProfileUpdated;
        public event EventHandler AvatarChanged;
        public event EventHandler ChangePasswordRequested;
        public event EventHandler LogoutRequested;
        public event EventHandler<ThemeChangedEventArgs> ThemeChanged;
        public event EventHandler<LanguageChangedEventArgs> LanguageChanged;

        protected virtual void OnProfileUpdated(EventArgs e)
        {
            ProfileUpdated?.Invoke(this, e);
        }

        protected virtual void OnAvatarChanged(EventArgs e)
        {
            AvatarChanged?.Invoke(this, e);
        }

        protected virtual void OnChangePasswordRequested(EventArgs e)
        {
            ChangePasswordRequested?.Invoke(this, e);
        }

        protected virtual void OnLogoutRequested(EventArgs e)
        {
            LogoutRequested?.Invoke(this, e);
        }

        protected virtual void OnThemeChanged(ThemeChangedEventArgs e)
        {
            ThemeChanged?.Invoke(this, e);
        }

        protected virtual void OnLanguageChanged(LanguageChangedEventArgs e)
        {
            LanguageChanged?.Invoke(this, e);
        }


        // Custom EventArgs cho Theme Changed



        // Load dữ liệu mẫu
        private void LoadSampleData()
        {
            txtFullName.Text = "Nguyễn Văn An";
            lblUserName.Text = "Nguyễn Văn An";
            lblRole.Text = "Quản trị viên";
            dateTimePickerBirthday.Value = new DateTime(1990, 5, 15);
            txtAddress.Text = "123 Đường Lê Lợi, Quận 1, TP. Hồ Chí Minh";
            txtPhone.Text = "0901 234 567";
            txtEmail.Text = "nguyenvanan@email.com";

            UpdateAvatar();
        }

        // Khởi tạo settings
        private void InitializeSettings()
        {
            cboLanguage.SelectedIndex = 0; // Mặc định Tiếng Việt
            toggleDarkMode.Checked = false;
        }

        // Cập nhật avatar
        private void UpdateAvatar()
        {
            Bitmap bmp = new Bitmap(120, 120);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Vẽ hình tròn nền
                g.FillEllipse(new SolidBrush(Color.FromArgb(33, 150, 243)), 0, 0, 120, 120);

                // Lấy chữ cái đầu
                string initials = GetInitials(txtFullName.Text);
                Font font = new Font("Segoe UI", 36, FontStyle.Bold);
                SizeF size = g.MeasureString(initials, font);

                // Vẽ chữ cái
                g.DrawString(initials, font, Brushes.White,
                    (120 - size.Width) / 2, (120 - size.Height) / 2);
            }
            pictureBoxAvatar.Image = bmp;
        }

        // Lấy chữ cái đầu
        private string GetInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return "NA";

            string[] parts = fullName.Trim().Split(' ');
            if (parts.Length >= 2)
            {
                return (parts[0][0].ToString() + parts[parts.Length - 1][0].ToString()).ToUpper();
            }
            return fullName.Substring(0, Math.Min(2, fullName.Length)).ToUpper();
        }

        // thuộc tính truy cập từ bên ngoài
        public DateTime Birthday
        {
            get { return dateTimePickerBirthday.Value; }
            set { dateTimePickerBirthday.Value = value; }
        }

        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }

        public string Phone
        {
            get { return txtPhone.Text; }
            set { txtPhone.Text = value; }
        }

        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

        public string UserRole
        {
            get { return lblRole.Text; }
            set { lblRole.Text = value; }
        }

        public Image Avatar
        {
            get { return pictureBoxAvatar.Image; }
            set { pictureBoxAvatar.Image = value; }
        }
        public class ThemeChangedEventArgs : EventArgs
        {
            public bool IsDarkMode { get; set; }

            public ThemeChangedEventArgs(bool isDarkMode)
            {
                IsDarkMode = isDarkMode;
            }
        }

        // Custom EventArgs cho Language Changed
        public class LanguageChangedEventArgs : EventArgs
        {
            public string Language { get; set; }

            public LanguageChangedEventArgs(string language)
            {
                Language = language;
            }
        }
    }
}

