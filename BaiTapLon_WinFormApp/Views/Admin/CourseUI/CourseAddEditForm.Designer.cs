namespace BaiTapLon_WinFormApp.Views.Admin.CourseUI
{
    partial class CourseAddEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCourseCode;
        private System.Windows.Forms.TextBox txtCourseCode;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.Label lblTutitionFee;
        private System.Windows.Forms.Label lblNumberSession;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhoneParents;
        private System.Windows.Forms.TextBox txtPhoneParents;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelButtons;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            lblCourseCode = new Label();
            txtCourseCode = new TextBox();
            lblCourseName = new Label();
            txtCourseName = new TextBox();
            lblTutitionFee = new Label();
            lblNumberSession = new Label();
            lblPhoneParents = new Label();
            lblDescription = new Label();
            txtDescription = new TextBox();
            panelButtons = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            lblLevel = new Label();
            cboLevel = new ComboBox();
            numTutitionFee = new NumericUpDown();
            numNumberSession = new NumericUpDown();
            panelHeader.SuspendLayout();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTutitionFee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNumberSession).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(63, 81, 181);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(700, 70);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(269, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Thêm khóa học mới";
            // 
            // lblCourseCode
            // 
            lblCourseCode.AutoSize = true;
            lblCourseCode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCourseCode.Location = new Point(30, 90);
            lblCourseCode.Name = "lblCourseCode";
            lblCourseCode.Size = new Size(125, 23);
            lblCourseCode.TabIndex = 1;
            lblCourseCode.Text = "Mã khóa học *";
            // 
            // txtCourseCode
            // 
            txtCourseCode.Font = new Font("Segoe UI", 11F);
            txtCourseCode.Location = new Point(30, 118);
            txtCourseCode.Name = "txtCourseCode";
            txtCourseCode.Size = new Size(300, 32);
            txtCourseCode.TabIndex = 0;
            // 
            // lblCourseName
            // 
            lblCourseName.AutoSize = true;
            lblCourseName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCourseName.Location = new Point(360, 90);
            lblCourseName.Name = "lblCourseName";
            lblCourseName.Size = new Size(122, 23);
            lblCourseName.TabIndex = 2;
            lblCourseName.Text = "Tên khóa học*";
            // 
            // txtCourseName
            // 
            txtCourseName.Font = new Font("Segoe UI", 11F);
            txtCourseName.Location = new Point(360, 118);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(300, 32);
            txtCourseName.TabIndex = 1;
            // 
            // lblTutitionFee
            // 
            lblTutitionFee.AutoSize = true;
            lblTutitionFee.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTutitionFee.Location = new Point(30, 165);
            lblTutitionFee.Name = "lblTutitionFee";
            lblTutitionFee.Size = new Size(149, 23);
            lblTutitionFee.TabIndex = 3;
            lblTutitionFee.Text = "Học phí ( VND ) *";
            // 
            // lblNumberSession
            // 
            lblNumberSession.AutoSize = true;
            lblNumberSession.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNumberSession.Location = new Point(360, 165);
            lblNumberSession.Name = "lblNumberSession";
            lblNumberSession.Size = new Size(112, 23);
            lblNumberSession.TabIndex = 4;
            lblNumberSession.Text = "Số buổi học*";
            // 
            // lblPhoneParents
            // 
            lblPhoneParents.AutoSize = true;
            lblPhoneParents.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPhoneParents.Location = new Point(327, 314);
            lblPhoneParents.Name = "lblPhoneParents";
            lblPhoneParents.Size = new Size(133, 23);
            lblPhoneParents.TabIndex = 6;
            lblPhoneParents.Text = "SĐT phụ huynh";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDescription.Location = new Point(30, 256);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(57, 23);
            lblDescription.TabIndex = 10;
            lblDescription.Text = "Mô tả";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 11F);
            txtDescription.Location = new Point(30, 291);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(630, 107);
            txtDescription.TabIndex = 9;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.FromArgb(245, 245, 245);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Location = new Point(0, 474);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(700, 64);
            panelButtons.TabIndex = 12;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(117, 117, 117);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(537, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 42);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "❌ Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 125, 50);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(411, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 42);
            btnSave.TabIndex = 13;
            btnSave.Text = "💾 Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLevel.Location = new Point(30, 414);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(90, 23);
            lblLevel.TabIndex = 13;
            lblLevel.Text = "Trình độ *";
            // 
            // cboLevel
            // 
            cboLevel.FormattingEnabled = true;
            cboLevel.Location = new Point(30, 440);
            cboLevel.Name = "cboLevel";
            cboLevel.Size = new Size(151, 28);
            cboLevel.TabIndex = 14;
            // 
            // numTutitionFee
            // 
            numTutitionFee.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            numTutitionFee.Location = new Point(30, 193);
            numTutitionFee.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numTutitionFee.Name = "numTutitionFee";
            numTutitionFee.Size = new Size(300, 27);
            numTutitionFee.TabIndex = 15;
            numTutitionFee.ThousandsSeparator = true;
            numTutitionFee.Value = new decimal(new int[] { 1000000, 0, 0, 0 });
            numTutitionFee.DecimalPlaces = 3;

            // 
            // numNumberSession
            // 
            numNumberSession.Location = new Point(360, 193);
            numNumberSession.Name = "numNumberSession";
            numNumberSession.Size = new Size(300, 27);
            numNumberSession.TabIndex = 16;
            numNumberSession.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // CourseAddEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(700, 545);
            Controls.Add(numNumberSession);
            Controls.Add(numTutitionFee);
            Controls.Add(cboLevel);
            Controls.Add(lblLevel);
            Controls.Add(panelButtons);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(lblPhoneParents);
            Controls.Add(lblNumberSession);
            Controls.Add(lblTutitionFee);
            Controls.Add(txtCourseName);
            Controls.Add(lblCourseName);
            Controls.Add(txtCourseCode);
            Controls.Add(lblCourseCode);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CourseAddEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm khóa học";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numTutitionFee).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNumberSession).EndInit();
            ResumeLayout(false);
            PerformLayout();
            #endregion
        }
        private Label lblLevel;
        private ComboBox cboLevel;
        private NumericUpDown numTutitionFee;
        private NumericUpDown numNumberSession;
    }
}