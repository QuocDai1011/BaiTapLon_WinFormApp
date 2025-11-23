namespace BaiTapLon_WinFormApp.Views.Admin.MyClassUI
{
    partial class ClassAddEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnClose;
        private Panel pnlMain;
        private Panel pnlLeft;
        private Panel pnlRight;
        private Panel pnlFooter;

        // Left panel controls
        private Label lblClassCode;
        private TextBox txtClassCode;
        private Label lblClassCodeError; // Error label
        private Label lblClassName;
        private TextBox txtClassName;
        private Label lblClassNameError; // Error label
        private Label lblMaxStudent;
        private NumericUpDown numMaxStudent;
        private Label lblMaxStudentError; // Error label
        private Label lblStartDate;
        private DateTimePicker dtpStartDate;
        private Label lblEndDate;
        private DateTimePicker dtpEndDate;

        // Right panel controls
        private Label lblShift;
        private ComboBox cboShift;
        private Label lblStatus;
        private CheckBox chkStatus;
        private Label lblOnlineMeetingLink;
        private TextBox txtOnlineMeetingLink;
        private Label lblOnlineMeetingLinkError; // Error label
        private Label lblNote;
        private TextBox txtNote;
        private Label lblNoteError; // Error label

        // Footer controls
        private Button btnCancel;
        private Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnClose = new Button();
            pnlMain = new Panel();
            pnlLeft = new Panel();
            lblClassCode = new Label();
            txtClassCode = new TextBox();
            lblClassCodeError = new Label();
            lblClassName = new Label();
            txtClassName = new TextBox();
            lblClassNameError = new Label();
            lblMaxStudent = new Label();
            numMaxStudent = new NumericUpDown();
            lblMaxStudentError = new Label();
            lblStartDate = new Label();
            dtpStartDate = new DateTimePicker();
            lblEndDate = new Label();
            dtpEndDate = new DateTimePicker();
            pnlRight = new Panel();
            lblShift = new Label();
            cboShift = new ComboBox();
            lblStatus = new Label();
            chkStatus = new CheckBox();
            lblOnlineMeetingLink = new Label();
            txtOnlineMeetingLink = new TextBox();
            lblOnlineMeetingLinkError = new Label();
            lblNote = new Label();
            txtNote = new TextBox();
            lblNoteError = new Label();
            pnlFooter = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxStudent).BeginInit();
            pnlRight.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(0, 120, 212);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(840, 60);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Thêm Lớp Học Mới";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.Transparent;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(788, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 40);
            btnClose.TabIndex = 1;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            btnClose.MouseEnter += BtnClose_MouseEnter;
            btnClose.MouseLeave += BtnClose_MouseLeave;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(248, 249, 250);
            pnlMain.Controls.Add(pnlLeft);
            pnlMain.Controls.Add(pnlRight);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(20);
            pnlMain.Size = new Size(840, 499);
            pnlMain.TabIndex = 0;
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.White;
            pnlLeft.Controls.Add(lblClassCode);
            pnlLeft.Controls.Add(txtClassCode);
            pnlLeft.Controls.Add(lblClassCodeError);
            pnlLeft.Controls.Add(lblClassName);
            pnlLeft.Controls.Add(txtClassName);
            pnlLeft.Controls.Add(lblClassNameError);
            pnlLeft.Controls.Add(lblMaxStudent);
            pnlLeft.Controls.Add(numMaxStudent);
            pnlLeft.Controls.Add(lblMaxStudentError);
            pnlLeft.Controls.Add(lblStartDate);
            pnlLeft.Controls.Add(dtpStartDate);
            pnlLeft.Controls.Add(lblEndDate);
            pnlLeft.Controls.Add(dtpEndDate);
            pnlLeft.Location = new Point(20, 20);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(20);
            pnlLeft.Size = new Size(380, 480);
            pnlLeft.TabIndex = 0;
            // 
            // lblClassCode
            // 
            lblClassCode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblClassCode.ForeColor = Color.FromArgb(33, 33, 33);
            lblClassCode.Location = new Point(20, 20);
            lblClassCode.Name = "lblClassCode";
            lblClassCode.Size = new Size(340, 25);
            lblClassCode.TabIndex = 0;
            lblClassCode.Text = "Mã Lớp *";
            // 
            // txtClassCode
            // 
            txtClassCode.BorderStyle = BorderStyle.FixedSingle;
            txtClassCode.Font = new Font("Segoe UI", 10F);
            txtClassCode.Location = new Point(20, 48);
            txtClassCode.MaxLength = 20;
            txtClassCode.Name = "txtClassCode";
            txtClassCode.Size = new Size(340, 30);
            txtClassCode.TabIndex = 1;
            txtClassCode.TextChanged += txtClassCode_TextChanged;
            txtClassCode.KeyDown += txtClassCode_KeyDown;
            // 
            // lblClassCodeError
            // 
            lblClassCodeError.Font = new Font("Segoe UI", 8.5F);
            lblClassCodeError.ForeColor = Color.FromArgb(220, 53, 69);
            lblClassCodeError.Location = new Point(20, 81);
            lblClassCodeError.Name = "lblClassCodeError";
            lblClassCodeError.Size = new Size(340, 18);
            lblClassCodeError.TabIndex = 2;
            lblClassCodeError.Visible = false;
            // 
            // lblClassName
            // 
            lblClassName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblClassName.ForeColor = Color.FromArgb(33, 33, 33);
            lblClassName.Location = new Point(20, 105);
            lblClassName.Name = "lblClassName";
            lblClassName.Size = new Size(340, 25);
            lblClassName.TabIndex = 3;
            lblClassName.Text = "Tên Lớp *";
            // 
            // txtClassName
            // 
            txtClassName.BorderStyle = BorderStyle.FixedSingle;
            txtClassName.Font = new Font("Segoe UI", 10F);
            txtClassName.Location = new Point(20, 133);
            txtClassName.MaxLength = 255;
            txtClassName.Name = "txtClassName";
            txtClassName.Size = new Size(340, 30);
            txtClassName.TabIndex = 4;
            txtClassName.TextChanged += txtClassName_TextChanged;
            txtClassName.KeyDown += txtClassName_KeyDown;
            // 
            // lblClassNameError
            // 
            lblClassNameError.Font = new Font("Segoe UI", 8.5F);
            lblClassNameError.ForeColor = Color.FromArgb(220, 53, 69);
            lblClassNameError.Location = new Point(20, 166);
            lblClassNameError.Name = "lblClassNameError";
            lblClassNameError.Size = new Size(340, 18);
            lblClassNameError.TabIndex = 5;
            lblClassNameError.Visible = false;
            // 
            // lblMaxStudent
            // 
            lblMaxStudent.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMaxStudent.ForeColor = Color.FromArgb(33, 33, 33);
            lblMaxStudent.Location = new Point(20, 190);
            lblMaxStudent.Name = "lblMaxStudent";
            lblMaxStudent.Size = new Size(340, 25);
            lblMaxStudent.TabIndex = 6;
            lblMaxStudent.Text = "Số Học Viên Tối Đa *";
            // 
            // numMaxStudent
            // 
            numMaxStudent.BorderStyle = BorderStyle.FixedSingle;
            numMaxStudent.Font = new Font("Segoe UI", 10F);
            numMaxStudent.Location = new Point(20, 218);
            numMaxStudent.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxStudent.Name = "numMaxStudent";
            numMaxStudent.Size = new Size(340, 30);
            numMaxStudent.TabIndex = 7;
            numMaxStudent.Value = new decimal(new int[] { 30, 0, 0, 0 });
            numMaxStudent.ValueChanged += numMaxStudent_ValueChanged;
            // 
            // lblMaxStudentError
            // 
            lblMaxStudentError.Font = new Font("Segoe UI", 8.5F);
            lblMaxStudentError.ForeColor = Color.FromArgb(220, 53, 69);
            lblMaxStudentError.Location = new Point(20, 251);
            lblMaxStudentError.Name = "lblMaxStudentError";
            lblMaxStudentError.Size = new Size(340, 18);
            lblMaxStudentError.TabIndex = 8;
            lblMaxStudentError.Visible = false;
            // 
            // lblStartDate
            // 
            lblStartDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStartDate.ForeColor = Color.FromArgb(33, 33, 33);
            lblStartDate.Location = new Point(20, 275);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(340, 25);
            lblStartDate.TabIndex = 9;
            lblStartDate.Text = "Ngày Bắt Đầu *";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Font = new Font("Segoe UI", 10F);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(20, 303);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(340, 30);
            dtpStartDate.TabIndex = 10;
            // 
            // lblEndDate
            // 
            lblEndDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEndDate.ForeColor = Color.FromArgb(33, 33, 33);
            lblEndDate.Location = new Point(20, 345);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(340, 25);
            lblEndDate.TabIndex = 11;
            lblEndDate.Text = "Ngày Kết Thúc *";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Font = new Font("Segoe UI", 10F);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(20, 373);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(340, 30);
            dtpEndDate.TabIndex = 12;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(lblShift);
            pnlRight.Controls.Add(cboShift);
            pnlRight.Controls.Add(lblStatus);
            pnlRight.Controls.Add(chkStatus);
            pnlRight.Controls.Add(lblOnlineMeetingLink);
            pnlRight.Controls.Add(txtOnlineMeetingLink);
            pnlRight.Controls.Add(lblOnlineMeetingLinkError);
            pnlRight.Controls.Add(lblNote);
            pnlRight.Controls.Add(txtNote);
            pnlRight.Controls.Add(lblNoteError);
            pnlRight.Location = new Point(420, 20);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(20);
            pnlRight.Size = new Size(380, 480);
            pnlRight.TabIndex = 1;
            // 
            // lblShift
            // 
            lblShift.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblShift.ForeColor = Color.FromArgb(33, 33, 33);
            lblShift.Location = new Point(20, 20);
            lblShift.Name = "lblShift";
            lblShift.Size = new Size(340, 25);
            lblShift.TabIndex = 0;
            lblShift.Text = "Ca Học *";
            // 
            // cboShift
            // 
            cboShift.DropDownStyle = ComboBoxStyle.DropDownList;
            cboShift.Font = new Font("Segoe UI", 10F);
            cboShift.Items.AddRange(new object[] { "Ca 1 (7:00 - 9:00)", "Ca 2 (9:30 - 11:30)", "Ca 3 (13:00 - 15:00)", "Ca 4 (15:30 - 17:30)", "Ca 5 (18:00 - 20:00)" });
            cboShift.Location = new Point(20, 48);
            cboShift.Name = "cboShift";
            cboShift.Size = new Size(340, 31);
            cboShift.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(33, 33, 33);
            lblStatus.Location = new Point(20, 90);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(340, 25);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Trạng Thái";
            // 
            // chkStatus
            // 
            chkStatus.Checked = true;
            chkStatus.CheckState = CheckState.Checked;
            chkStatus.Font = new Font("Segoe UI", 10F);
            chkStatus.ForeColor = Color.FromArgb(66, 66, 66);
            chkStatus.Location = new Point(20, 118);
            chkStatus.Name = "chkStatus";
            chkStatus.Size = new Size(340, 30);
            chkStatus.TabIndex = 3;
            chkStatus.Text = "Lớp đang hoạt động";
            // 
            // lblOnlineMeetingLink
            // 
            lblOnlineMeetingLink.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblOnlineMeetingLink.ForeColor = Color.FromArgb(33, 33, 33);
            lblOnlineMeetingLink.Location = new Point(20, 160);
            lblOnlineMeetingLink.Name = "lblOnlineMeetingLink";
            lblOnlineMeetingLink.Size = new Size(340, 25);
            lblOnlineMeetingLink.TabIndex = 4;
            lblOnlineMeetingLink.Text = "Link Học Online";
            // 
            // txtOnlineMeetingLink
            // 
            txtOnlineMeetingLink.BorderStyle = BorderStyle.FixedSingle;
            txtOnlineMeetingLink.Font = new Font("Segoe UI", 10F);
            txtOnlineMeetingLink.Location = new Point(20, 188);
            txtOnlineMeetingLink.Name = "txtOnlineMeetingLink";
            txtOnlineMeetingLink.PlaceholderText = "https://meet.google.com/...";
            txtOnlineMeetingLink.Size = new Size(340, 30);
            txtOnlineMeetingLink.TabIndex = 5;
            txtOnlineMeetingLink.TextChanged += txtOnlineMeetingLink_TextChanged;
            // 
            // lblOnlineMeetingLinkError
            // 
            lblOnlineMeetingLinkError.Font = new Font("Segoe UI", 8.5F);
            lblOnlineMeetingLinkError.ForeColor = Color.FromArgb(220, 53, 69);
            lblOnlineMeetingLinkError.Location = new Point(20, 221);
            lblOnlineMeetingLinkError.Name = "lblOnlineMeetingLinkError";
            lblOnlineMeetingLinkError.Size = new Size(340, 18);
            lblOnlineMeetingLinkError.TabIndex = 6;
            lblOnlineMeetingLinkError.Visible = false;
            // 
            // lblNote
            // 
            lblNote.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNote.ForeColor = Color.FromArgb(33, 33, 33);
            lblNote.Location = new Point(20, 245);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(340, 25);
            lblNote.TabIndex = 7;
            lblNote.Text = "Ghi Chú";
            // 
            // txtNote
            // 
            txtNote.BorderStyle = BorderStyle.FixedSingle;
            txtNote.Font = new Font("Segoe UI", 10F);
            txtNote.Location = new Point(20, 273);
            txtNote.MaxLength = 255;
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.ScrollBars = ScrollBars.Vertical;
            txtNote.Size = new Size(340, 100);
            txtNote.TabIndex = 8;
            txtNote.TextChanged += txtNote_TextChanged;
            // 
            // lblNoteError
            // 
            lblNoteError.Font = new Font("Segoe UI", 8.5F);
            lblNoteError.ForeColor = Color.FromArgb(220, 53, 69);
            lblNoteError.Location = new Point(20, 376);
            lblNoteError.Name = "lblNoteError";
            lblNoteError.Size = new Size(340, 18);
            lblNoteError.TabIndex = 9;
            lblNoteError.Visible = false;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.White;
            pnlFooter.Controls.Add(btnCancel);
            pnlFooter.Controls.Add(btnSave);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 559);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Padding = new Padding(20);
            pnlFooter.Size = new Size(840, 71);
            pnlFooter.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.FromArgb(230, 230, 230);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(66, 66, 66);
            btnCancel.Location = new Point(687, 14);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 45);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnClose_Click;
            btnCancel.MouseEnter += BtnCancel_MouseEnter;
            btnCancel.MouseLeave += BtnCancel_MouseLeave;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(0, 120, 212);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(523, 14);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 45);
            btnSave.TabIndex = 1;
            btnSave.Text = "Lưu Lớp Học";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            btnSave.MouseEnter += BtnSave_MouseEnter;
            btnSave.MouseLeave += BtnSave_MouseLeave;
            // 
            // ClassAddEditForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(840, 630);
            Controls.Add(pnlMain);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ClassAddEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm Lớp Học";
            pnlHeader.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxStudent).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        // Hover effects for buttons
        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(192, 0, 0);
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Transparent;
        }

        private void BtnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(210, 210, 210);
        }

        private void BtnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(230, 230, 230);
        }

        private void BtnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(0, 100, 190);
        }

        private void BtnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(0, 120, 212);
        }
    }
}