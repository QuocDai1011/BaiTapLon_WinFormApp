


namespace BaiTapLon_WinFormApp.Views.Admin.ProfileUI
{
    partial class UserProfile
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMain = new Panel();
            panelContent = new Panel();
            panelSettings = new Panel();
            btnLogout = new Button();
            panelLanguage = new Panel();
            cboLanguage = new ComboBox();
            lblLanguage = new Label();
            panelTheme = new Panel();
            toggleDarkMode = new CheckBox();
            lblTheme = new Label();
            lblSettingsTitle = new Label();
            panelProfile = new Panel();
            btnChangePassword = new Button();
            btnSave = new Button();
            btnEdit = new Button();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            dateTimePickerBirthday = new DateTimePicker();
            lblBirthday = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            lblProfileTitle = new Label();
            panelHeader = new Panel();
            lblRole = new Label();
            lblUserName = new Label();
            btnChangeAvatar = new Button();
            pictureBoxAvatar = new PictureBox();
            panelMain.SuspendLayout();
            panelContent.SuspendLayout();
            panelSettings.SuspendLayout();
            panelLanguage.SuspendLayout();
            panelTheme.SuspendLayout();
            panelProfile.SuspendLayout();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAvatar).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(245, 245, 245);
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(4, 5, 4, 5);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(27, 31, 27, 31);
            panelMain.Size = new Size(1594, 1077);
            panelMain.TabIndex = 0;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(panelSettings);
            panelContent.Controls.Add(panelProfile);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(27, 339);
            panelContent.Margin = new Padding(4, 5, 4, 5);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1540, 707);
            panelContent.TabIndex = 1;
            // 
            // panelSettings
            // 
            panelSettings.BackColor = Color.White;
            panelSettings.Controls.Add(btnLogout);
            panelSettings.Controls.Add(panelLanguage);
            panelSettings.Controls.Add(panelTheme);
            panelSettings.Controls.Add(lblSettingsTitle);
            panelSettings.Location = new Point(820, 0);
            panelSettings.Margin = new Padding(4, 5, 4, 5);
            panelSettings.Name = "panelSettings";
            panelSettings.Padding = new Padding(33, 38, 33, 38);
            panelSettings.Size = new Size(692, 708);
            panelSettings.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(244, 67, 54);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(33, 600);
            btnLogout.Margin = new Padding(4, 5, 4, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(622, 69);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "🚪 ĐĂNG XUẤT";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // panelLanguage
            // 
            panelLanguage.BackColor = Color.FromArgb(250, 250, 250);
            panelLanguage.Controls.Add(cboLanguage);
            panelLanguage.Controls.Add(lblLanguage);
            panelLanguage.Location = new Point(33, 323);
            panelLanguage.Margin = new Padding(4, 5, 4, 5);
            panelLanguage.Name = "panelLanguage";
            panelLanguage.Padding = new Padding(27, 31, 27, 31);
            panelLanguage.Size = new Size(626, 138);
            panelLanguage.TabIndex = 2;
            // 
            // cboLanguage
            // 
            cboLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLanguage.Font = new Font("Segoe UI", 10F);
            cboLanguage.FormattingEnabled = true;
            cboLanguage.Items.AddRange(new object[] { "🇻🇳 Tiếng Việt", "🇬🇧 English", "🇯🇵 日本語", "🇰🇷 한국어", "🇨🇳 中文" });
            cboLanguage.Location = new Point(162, 58);
            cboLanguage.Margin = new Padding(4, 5, 4, 5);
            cboLanguage.Name = "cboLanguage";
            cboLanguage.Size = new Size(332, 31);
            cboLanguage.TabIndex = 1;
            cboLanguage.SelectedIndexChanged += cboLanguage_SelectedIndexChanged;
            // 
            // lblLanguage
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLanguage.ForeColor = Color.FromArgb(66, 66, 66);
            lblLanguage.Location = new Point(27, 15);
            lblLanguage.Margin = new Padding(4, 0, 4, 0);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(238, 25);
            lblLanguage.TabIndex = 0;
            lblLanguage.Text = "🌐 Ngôn ngữ / Language";
            // 
            // panelTheme
            // 
            panelTheme.BackColor = Color.FromArgb(250, 250, 250);
            panelTheme.Controls.Add(toggleDarkMode);
            panelTheme.Controls.Add(lblTheme);
            panelTheme.Location = new Point(33, 138);
            panelTheme.Margin = new Padding(4, 5, 4, 5);
            panelTheme.Name = "panelTheme";
            panelTheme.Padding = new Padding(27, 31, 27, 31);
            panelTheme.Size = new Size(626, 138);
            panelTheme.TabIndex = 1;
            // 
            // toggleDarkMode
            // 
            toggleDarkMode.Appearance = Appearance.Button;
            toggleDarkMode.BackColor = Color.FromArgb(224, 224, 224);
            toggleDarkMode.Cursor = Cursors.Hand;
            toggleDarkMode.FlatAppearance.BorderSize = 0;
            toggleDarkMode.FlatAppearance.CheckedBackColor = Color.FromArgb(33, 150, 243);
            toggleDarkMode.FlatStyle = FlatStyle.Flat;
            toggleDarkMode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            toggleDarkMode.Location = new Point(162, 58);
            toggleDarkMode.Margin = new Padding(4, 5, 4, 5);
            toggleDarkMode.Name = "toggleDarkMode";
            toggleDarkMode.Size = new Size(333, 54);
            toggleDarkMode.TabIndex = 1;
            toggleDarkMode.Text = "☀️ Chế độ sáng";
            toggleDarkMode.TextAlign = ContentAlignment.MiddleCenter;
            toggleDarkMode.UseVisualStyleBackColor = false;
            toggleDarkMode.CheckedChanged += toggleDarkMode_CheckedChanged;
            // 
            // lblTheme
            // 
            lblTheme.AutoSize = true;
            lblTheme.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTheme.ForeColor = Color.FromArgb(66, 66, 66);
            lblTheme.Location = new Point(27, 15);
            lblTheme.Margin = new Padding(4, 0, 4, 0);
            lblTheme.Name = "lblTheme";
            lblTheme.Size = new Size(124, 25);
            lblTheme.TabIndex = 0;
            lblTheme.Text = "🎨 Giao diện";
            // 
            // lblSettingsTitle
            // 
            lblSettingsTitle.Dock = DockStyle.Top;
            lblSettingsTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSettingsTitle.ForeColor = Color.FromArgb(33, 150, 243);
            lblSettingsTitle.Location = new Point(33, 38);
            lblSettingsTitle.Margin = new Padding(4, 0, 4, 0);
            lblSettingsTitle.Name = "lblSettingsTitle";
            lblSettingsTitle.Size = new Size(626, 62);
            lblSettingsTitle.TabIndex = 0;
            lblSettingsTitle.Text = "⚙️ CÀI ĐẶT";
            lblSettingsTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelProfile
            // 
            panelProfile.BackColor = Color.White;
            panelProfile.Controls.Add(btnChangePassword);
            panelProfile.Controls.Add(btnSave);
            panelProfile.Controls.Add(btnEdit);
            panelProfile.Controls.Add(txtEmail);
            panelProfile.Controls.Add(lblEmail);
            panelProfile.Controls.Add(txtPhone);
            panelProfile.Controls.Add(lblPhone);
            panelProfile.Controls.Add(txtAddress);
            panelProfile.Controls.Add(lblAddress);
            panelProfile.Controls.Add(dateTimePickerBirthday);
            panelProfile.Controls.Add(lblBirthday);
            panelProfile.Controls.Add(txtFullName);
            panelProfile.Controls.Add(lblFullName);
            panelProfile.Controls.Add(lblProfileTitle);
            panelProfile.Location = new Point(30, 0);
            panelProfile.Margin = new Padding(4, 5, 4, 5);
            panelProfile.Name = "panelProfile";
            panelProfile.Padding = new Padding(33, 38, 33, 38);
            panelProfile.Size = new Size(692, 708);
            panelProfile.TabIndex = 0;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.FromArgb(255, 152, 0);
            btnChangePassword.Cursor = Cursors.Hand;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.Location = new Point(366, 600);
            btnChangePassword.Margin = new Padding(4, 5, 4, 5);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(267, 62);
            btnChangePassword.TabIndex = 13;
            btnChangePassword.Text = "🔒 Đổi mật khẩu";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 125, 50);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(207, 600);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(145, 62);
            btnSave.TabIndex = 12;
            btnSave.Text = "💾 Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Visible = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(33, 150, 243);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(37, 600);
            btnEdit.Margin = new Padding(4, 5, 4, 5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(155, 62);
            btnEdit.TabIndex = 11;
            btnEdit.Text = "✏️ Chỉnh sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.WhiteSmoke;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(207, 508);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(426, 30);
            txtEmail.TabIndex = 10;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(66, 66, 66);
            lblEmail.Location = new Point(33, 512);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(59, 23);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Email:";
            // 
            // txtPhone
            // 
            txtPhone.BackColor = Color.WhiteSmoke;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(207, 431);
            txtPhone.Margin = new Padding(4, 5, 4, 5);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(426, 30);
            txtPhone.TabIndex = 8;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(66, 66, 66);
            lblPhone.Location = new Point(33, 435);
            lblPhone.Margin = new Padding(4, 0, 4, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(121, 23);
            lblPhone.TabIndex = 7;
            lblPhone.Text = "Số điện thoại:";
            // 
            // txtAddress
            // 
            txtAddress.BackColor = Color.WhiteSmoke;
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(207, 354);
            txtAddress.Margin = new Padding(4, 5, 4, 5);
            txtAddress.Name = "txtAddress";
            txtAddress.ReadOnly = true;
            txtAddress.Size = new Size(426, 30);
            txtAddress.TabIndex = 6;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(66, 66, 66);
            lblAddress.Location = new Point(33, 358);
            lblAddress.Margin = new Padding(4, 0, 4, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(70, 23);
            lblAddress.TabIndex = 5;
            lblAddress.Text = "Địa chỉ:";
            // 
            // dateTimePickerBirthday
            // 
            dateTimePickerBirthday.Enabled = false;
            dateTimePickerBirthday.Font = new Font("Segoe UI", 10F);
            dateTimePickerBirthday.Format = DateTimePickerFormat.Short;
            dateTimePickerBirthday.Location = new Point(207, 277);
            dateTimePickerBirthday.Margin = new Padding(4, 5, 4, 5);
            dateTimePickerBirthday.Name = "dateTimePickerBirthday";
            dateTimePickerBirthday.Size = new Size(426, 30);
            dateTimePickerBirthday.TabIndex = 4;
            // 
            // lblBirthday
            // 
            lblBirthday.AutoSize = true;
            lblBirthday.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBirthday.ForeColor = Color.FromArgb(66, 66, 66);
            lblBirthday.Location = new Point(33, 282);
            lblBirthday.Margin = new Padding(4, 0, 4, 0);
            lblBirthday.Name = "lblBirthday";
            lblBirthday.Size = new Size(94, 23);
            lblBirthday.TabIndex = 3;
            lblBirthday.Text = "Ngày sinh:";
            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.WhiteSmoke;
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.Location = new Point(207, 200);
            txtFullName.Margin = new Padding(4, 5, 4, 5);
            txtFullName.Name = "txtFullName";
            txtFullName.ReadOnly = true;
            txtFullName.Size = new Size(426, 30);
            txtFullName.TabIndex = 2;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(66, 66, 66);
            lblFullName.Location = new Point(33, 205);
            lblFullName.Margin = new Padding(4, 0, 4, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(69, 23);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Họ tên:";
            // 
            // lblProfileTitle
            // 
            lblProfileTitle.Dock = DockStyle.Top;
            lblProfileTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblProfileTitle.ForeColor = Color.FromArgb(33, 150, 243);
            lblProfileTitle.Location = new Point(33, 38);
            lblProfileTitle.Margin = new Padding(4, 0, 4, 0);
            lblProfileTitle.Name = "lblProfileTitle";
            lblProfileTitle.Size = new Size(626, 62);
            lblProfileTitle.TabIndex = 0;
            lblProfileTitle.Text = "👤 THÔNG TIN CÁ NHÂN";
            lblProfileTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblRole);
            panelHeader.Controls.Add(lblUserName);
            panelHeader.Controls.Add(btnChangeAvatar);
            panelHeader.Controls.Add(pictureBoxAvatar);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(27, 31);
            panelHeader.Margin = new Padding(4, 5, 4, 5);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1540, 308);
            panelHeader.TabIndex = 0;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 11F);
            lblRole.ForeColor = Color.Gray;
            lblRole.Location = new Point(301, 177);
            lblRole.Margin = new Padding(4, 0, 4, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(113, 25);
            lblRole.TabIndex = 3;
            lblRole.Text = "Người dùng";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblUserName.ForeColor = Color.FromArgb(33, 150, 243);
            lblUserName.Location = new Point(299, 108);
            lblUserName.Margin = new Padding(4, 0, 4, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(236, 41);
            lblUserName.TabIndex = 2;
            lblUserName.Text = "Nguyễn Văn An";
            // 
            // btnChangeAvatar
            // 
            btnChangeAvatar.BackColor = Color.FromArgb(33, 150, 243);
            btnChangeAvatar.Cursor = Cursors.Hand;
            btnChangeAvatar.FlatAppearance.BorderSize = 0;
            btnChangeAvatar.FlatStyle = FlatStyle.Flat;
            btnChangeAvatar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnChangeAvatar.ForeColor = Color.White;
            btnChangeAvatar.Location = new Point(67, 231);
            btnChangeAvatar.Margin = new Padding(4, 5, 4, 5);
            btnChangeAvatar.Name = "btnChangeAvatar";
            btnChangeAvatar.Size = new Size(160, 46);
            btnChangeAvatar.TabIndex = 1;
            btnChangeAvatar.Text = "📷 Đổi ảnh";
            btnChangeAvatar.UseVisualStyleBackColor = false;
            btnChangeAvatar.Click += btnChangeAvatar_Click;
            // 
            // pictureBoxAvatar
            // 
            pictureBoxAvatar.BackColor = Color.LightGray;
            pictureBoxAvatar.Location = new Point(67, 46);
            pictureBoxAvatar.Margin = new Padding(4, 5, 4, 5);
            pictureBoxAvatar.Name = "pictureBoxAvatar";
            pictureBoxAvatar.Size = new Size(160, 185);
            pictureBoxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAvatar.TabIndex = 0;
            pictureBoxAvatar.TabStop = false;
            // 
            // UserProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelMain);
            Margin = new Padding(4, 5, 4, 5);
            Name = "UserProfile";
            Size = new Size(1594, 1077);
            panelMain.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelSettings.ResumeLayout(false);
            panelLanguage.ResumeLayout(false);
            panelLanguage.PerformLayout();
            panelTheme.ResumeLayout(false);
            panelTheme.PerformLayout();
            panelProfile.ResumeLayout(false);
            panelProfile.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAvatar).EndInit();
            ResumeLayout(false);

        }





        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.Button btnChangeAvatar;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelProfile;
        private System.Windows.Forms.Label lblProfileTitle;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirthday;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label lblSettingsTitle;
        private System.Windows.Forms.Panel panelTheme;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.CheckBox toggleDarkMode;
        private System.Windows.Forms.Panel panelLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cboLanguage;
        private System.Windows.Forms.Button btnLogout;
    }
}
