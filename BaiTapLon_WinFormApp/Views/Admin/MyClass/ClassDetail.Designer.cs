namespace BaiTapLon_WinFormApp.Views.Admin.MyClass
{
    partial class ClassDetail
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            lblTitle = new Label();
            panel1 = new Panel();
            btnOpenClass = new Button();
            lblNote = new Label();
            label12 = new Label();
            lblOnlineLink = new Label();
            lblMethod = new Label();
            lblMaxStudent = new Label();
            lblEndDate = new Label();
            lblShift = new Label();
            lblStatus = new Label();
            lblCurrentStudent = new Label();
            lblStartDate = new Label();
            lblClassName = new Label();
            lblClassCode = new Label();
            label10 = new Label();
            lblTitleOnlineLink = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvStudents = new DataGridView();
            colSTT = new DataGridViewTextBoxColumn();
            colId = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colGender = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colDateOfBirth = new DataGridViewTextBoxColumn();
            colPhoneNumber = new DataGridViewTextBoxColumn();
            colPhoneNumberOfParent = new DataGridViewTextBoxColumn();
            panelActions = new Panel();
            btnAdd = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnExport = new Button();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Controls.Add(dgvStudents);
            flowLayoutPanel1.Controls.Add(panelActions);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1508, 880);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(33, 150, 243);
            panel2.Controls.Add(lblTitle);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1502, 112);
            panel2.TabIndex = 20;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(57, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(340, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chi tiết lớp học";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnOpenClass);
            panel1.Controls.Add(lblNote);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(lblOnlineLink);
            panel1.Controls.Add(lblMethod);
            panel1.Controls.Add(lblMaxStudent);
            panel1.Controls.Add(lblEndDate);
            panel1.Controls.Add(lblShift);
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(lblCurrentStudent);
            panel1.Controls.Add(lblStartDate);
            panel1.Controls.Add(lblClassName);
            panel1.Controls.Add(lblClassCode);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(lblTitleOnlineLink);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(3, 121);
            panel1.Name = "panel1";
            panel1.Size = new Size(1502, 216);
            panel1.TabIndex = 4;
            // 
            // btnOpenClass
            // 
            btnOpenClass.BackColor = Color.FromArgb(30, 136, 229);
            btnOpenClass.FlatAppearance.BorderSize = 0;
            btnOpenClass.FlatStyle = FlatStyle.Flat;
            btnOpenClass.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOpenClass.ForeColor = Color.White;
            btnOpenClass.Location = new Point(1093, 161);
            btnOpenClass.Name = "btnOpenClass";
            btnOpenClass.Size = new Size(142, 38);
            btnOpenClass.TabIndex = 22;
            btnOpenClass.Text = "📖 Mở lớp học";
            btnOpenClass.UseVisualStyleBackColor = false;
            btnOpenClass.Click += btnOpenClass_Click;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Location = new Point(1174, 70);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(58, 20);
            lblNote.TabIndex = 21;
            lblNote.Text = "label18";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label12.Location = new Point(1093, 67);
            label12.Name = "label12";
            label12.Size = new Size(75, 23);
            label12.TabIndex = 20;
            label12.Text = "Ghi chú:";
            // 
            // lblOnlineLink
            // 
            lblOnlineLink.AutoSize = true;
            lblOnlineLink.Location = new Point(1270, 124);
            lblOnlineLink.Name = "lblOnlineLink";
            lblOnlineLink.Size = new Size(58, 20);
            lblOnlineLink.TabIndex = 19;
            lblOnlineLink.Text = "label20";
            // 
            // lblMethod
            // 
            lblMethod.AutoSize = true;
            lblMethod.Location = new Point(1226, 25);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(58, 20);
            lblMethod.TabIndex = 18;
            lblMethod.Text = "label19";
            // 
            // lblMaxStudent
            // 
            lblMaxStudent.AutoSize = true;
            lblMaxStudent.Location = new Point(803, 170);
            lblMaxStudent.Name = "lblMaxStudent";
            lblMaxStudent.Size = new Size(58, 20);
            lblMaxStudent.TabIndex = 17;
            lblMaxStudent.Text = "label18";
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(790, 124);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(58, 20);
            lblEndDate.TabIndex = 16;
            lblEndDate.Text = "label17";
            // 
            // lblShift
            // 
            lblShift.AutoSize = true;
            lblShift.Location = new Point(730, 70);
            lblShift.Name = "lblShift";
            lblShift.Size = new Size(58, 20);
            lblShift.TabIndex = 15;
            lblShift.Text = "label16";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(759, 25);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(58, 20);
            lblStatus.TabIndex = 14;
            lblStatus.Text = "label15";
            // 
            // lblCurrentStudent
            // 
            lblCurrentStudent.AutoSize = true;
            lblCurrentStudent.Location = new Point(219, 171);
            lblCurrentStudent.Name = "lblCurrentStudent";
            lblCurrentStudent.Size = new Size(58, 20);
            lblCurrentStudent.TabIndex = 13;
            lblCurrentStudent.Text = "label14";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(185, 124);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(58, 20);
            lblStartDate.TabIndex = 12;
            lblStartDate.Text = "label13";
            // 
            // lblClassName
            // 
            lblClassName.AutoSize = true;
            lblClassName.Location = new Point(137, 70);
            lblClassName.Name = "lblClassName";
            lblClassName.Size = new Size(58, 20);
            lblClassName.TabIndex = 11;
            lblClassName.Text = "label12";
            // 
            // lblClassCode
            // 
            lblClassCode.AutoSize = true;
            lblClassCode.Location = new Point(137, 25);
            lblClassCode.Name = "lblClassCode";
            lblClassCode.Size = new Size(58, 20);
            lblClassCode.TabIndex = 10;
            lblClassCode.Text = "label11";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label10.Location = new Point(1093, 22);
            label10.Name = "label10";
            label10.Size = new Size(127, 23);
            label10.TabIndex = 9;
            label10.Text = "Hình thức học:";
            // 
            // lblTitleOnlineLink
            // 
            lblTitleOnlineLink.AutoSize = true;
            lblTitleOnlineLink.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblTitleOnlineLink.Location = new Point(1093, 121);
            lblTitleOnlineLink.Name = "lblTitleOnlineLink";
            lblTitleOnlineLink.Size = new Size(171, 23);
            lblTitleOnlineLink.TabIndex = 8;
            lblTitleOnlineLink.Text = "link học trực tuyến: ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label8.Location = new Point(656, 22);
            label8.Name = "label8";
            label8.Size = new Size(97, 23);
            label8.TabIndex = 7;
            label8.Text = "Trạng thái:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label7.Location = new Point(656, 67);
            label7.Name = "label7";
            label7.Size = new Size(68, 23);
            label7.TabIndex = 6;
            label7.Text = "Ca học:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label6.Location = new Point(656, 168);
            label6.Name = "label6";
            label6.Size = new Size(145, 23);
            label6.TabIndex = 5;
            label6.Text = "Sinh viên tối đa: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label5.Location = new Point(55, 168);
            label5.Name = "label5";
            label5.Size = new Size(158, 23);
            label5.TabIndex = 4;
            label5.Text = "Sinh viên hiện tại: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.Location = new Point(656, 121);
            label4.Name = "label4";
            label4.Size = new Size(128, 23);
            label4.TabIndex = 3;
            label4.Text = "Ngày kết thúc:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.Location = new Point(55, 121);
            label3.Name = "label3";
            label3.Size = new Size(124, 23);
            label3.TabIndex = 2;
            label3.Text = "Ngày bắt đầu:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(57, 67);
            label2.Name = "label2";
            label2.Size = new Size(74, 23);
            label2.TabIndex = 1;
            label2.Text = "Tên lớp:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(57, 22);
            label1.Name = "label1";
            label1.Size = new Size(72, 23);
            label1.TabIndex = 0;
            label1.Text = "Mã lớp:";
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dgvStudents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dgvStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvStudents.ColumnHeadersHeight = 50;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvStudents.Columns.AddRange(new DataGridViewColumn[] { colSTT, colId, colFullName, colGender, colEmail, colDateOfBirth, colPhoneNumber, colPhoneNumberOfParent });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(33, 33, 33);
            dataGridViewCellStyle3.Padding = new Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(232, 234, 246);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvStudents.DefaultCellStyle = dataGridViewCellStyle3;
            dgvStudents.EnableHeadersVisualStyles = false;
            dgvStudents.GridColor = Color.LightGray;
            dgvStudents.Location = new Point(3, 343);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.RowTemplate.Height = 45;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(1502, 418);
            dgvStudents.TabIndex = 2;
            // 
            // colSTT
            // 
            colSTT.HeaderText = "STT";
            colSTT.MinimumWidth = 6;
            colSTT.Name = "colSTT";
            colSTT.ReadOnly = true;
            // 
            // colId
            // 
            colId.HeaderText = "Mã sinh viên";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colFullName
            // 
            colFullName.HeaderText = "Họ và tên";
            colFullName.MinimumWidth = 6;
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            // 
            // colGender
            // 
            colGender.HeaderText = "Giới tính";
            colGender.MinimumWidth = 6;
            colGender.Name = "colGender";
            colGender.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colDateOfBirth
            // 
            colDateOfBirth.HeaderText = "Ngày sinh";
            colDateOfBirth.MinimumWidth = 6;
            colDateOfBirth.Name = "colDateOfBirth";
            colDateOfBirth.ReadOnly = true;
            // 
            // colPhoneNumber
            // 
            colPhoneNumber.HeaderText = "SĐT";
            colPhoneNumber.MinimumWidth = 6;
            colPhoneNumber.Name = "colPhoneNumber";
            colPhoneNumber.ReadOnly = true;
            // 
            // colPhoneNumberOfParent
            // 
            colPhoneNumberOfParent.HeaderText = "SĐT phụ huynh";
            colPhoneNumberOfParent.MinimumWidth = 6;
            colPhoneNumberOfParent.Name = "colPhoneNumberOfParent";
            colPhoneNumberOfParent.ReadOnly = true;
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.FromArgb(250, 250, 250);
            panelActions.Controls.Add(btnAdd);
            panelActions.Controls.Add(btnDelete);
            panelActions.Controls.Add(btnRefresh);
            panelActions.Controls.Add(btnExport);
            panelActions.Location = new Point(3, 767);
            panelActions.Name = "panelActions";
            panelActions.Padding = new Padding(20, 15, 20, 15);
            panelActions.Size = new Size(1502, 94);
            panelActions.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(46, 125, 50);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(20, 18);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 38);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "➕ Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(211, 47, 47);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(185, 18);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 38);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(117, 117, 117);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(1174, 17);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 38);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "🔄 Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(0, 150, 136);
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(1309, 17);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(140, 38);
            btnExport.TabIndex = 5;
            btnExport.Text = "📥 Xuất Excel";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // ClassDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel1);
            Name = "ClassDetail";
            Size = new Size(1508, 880);
            flowLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            panelActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private DataGridView dgvStudents;
        private DataGridViewTextBoxColumn colSTT;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colGender;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colDateOfBirth;
        private DataGridViewTextBoxColumn colPhoneNumber;
        private DataGridViewTextBoxColumn colPhoneNumberOfParent;
        private Panel panelActions;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnExport;
        private Panel panel1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label10;
        private Label lblTitleOnlineLink;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label lblOnlineLink;
        private Label lblMethod;
        private Label lblMaxStudent;
        private Label lblEndDate;
        private Label lblShift;
        private Label lblStatus;
        private Label lblCurrentStudent;
        private Label lblStartDate;
        private Label lblClassName;
        private Label lblClassCode;
        private Panel panel2;
        private Label lblTitle;
        private Label lblNote;
        private Label label12;
        private Button btnOpenClass;
    }
}
