
namespace BaiTapLon_WinFormApp.Views.Admin.CourseUI
{
    partial class ManageCourse
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTotalCourses;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelActions;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            lblTitle = new Label();
            lblTotalCourses = new Label();
            panelActions = new Panel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            dgvCourses = new DataGridView();
            colCourseId = new DataGridViewTextBoxColumn();
            colCourseCode = new DataGridViewTextBoxColumn();
            colCourseName = new DataGridViewTextBoxColumn();
            colTutitionFee = new DataGridViewTextBoxColumn();
            colNumberSession = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colLevel = new DataGridViewTextBoxColumn();
            panelHeader.SuspendLayout();
            panelActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblTotalCourses);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(20, 15, 20, 15);
            panelHeader.Size = new Size(1400, 80);
            panelHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 33, 33);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(296, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Danh sách khóa học";
            // 
            // lblTotalCourses
            // 
            lblTotalCourses.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalCourses.Font = new Font("Segoe UI", 12F);
            lblTotalCourses.ForeColor = Color.FromArgb(117, 117, 117);
            lblTotalCourses.Location = new Point(1080, 25);
            lblTotalCourses.Name = "lblTotalCourses";
            lblTotalCourses.Size = new Size(300, 25);
            lblTotalCourses.TabIndex = 1;
            lblTotalCourses.Text = "Tổng số: 0 sinh viên";
            lblTotalCourses.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.FromArgb(250, 250, 250);
            panelActions.Controls.Add(btnAdd);
            panelActions.Controls.Add(btnEdit);
            panelActions.Controls.Add(btnDelete);
            panelActions.Controls.Add(btnRefresh);
            panelActions.Dock = DockStyle.Top;
            panelActions.Location = new Point(0, 80);
            panelActions.Name = "panelActions";
            panelActions.Padding = new Padding(20, 15, 20, 15);
            panelActions.Size = new Size(1400, 80);
            panelActions.TabIndex = 1;
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
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(25, 118, 210);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(176, 17);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 38);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "✏️ Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(211, 47, 47);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(302, 17);
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
            btnRefresh.Location = new Point(1232, 18);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 38);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "🔄 Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvCourses
            // 
            dgvCourses.AllowUserToAddRows = false;
            dgvCourses.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(245, 245, 245);
            dgvCourses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCourses.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvCourses.BackgroundColor = Color.White;
            dgvCourses.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.Padding = new Padding(5);
            dgvCourses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvCourses.ColumnHeadersHeight = 50;
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCourses.Columns.AddRange(new DataGridViewColumn[] { colCourseId, colCourseCode, colCourseName, colTutitionFee, colNumberSession, colDescription, colLevel });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(33, 33, 33);
            dataGridViewCellStyle8.Padding = new Padding(5);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(232, 234, 246);
            dataGridViewCellStyle8.SelectionForeColor = Color.Black;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvCourses.DefaultCellStyle = dataGridViewCellStyle8;
            dgvCourses.Dock = DockStyle.Fill;
            dgvCourses.EnableHeadersVisualStyles = false;
            dgvCourses.GridColor = Color.LightGray;
            dgvCourses.Location = new Point(0, 160);
            dgvCourses.MultiSelect = false;
            dgvCourses.Name = "dgvCourses";
            dgvCourses.ReadOnly = true;
            dgvCourses.RowHeadersWidth = 51;
            dgvCourses.RowTemplate.Height = 45;
            dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCourses.Size = new Size(1400, 640);
            dgvCourses.TabIndex = 0;
            // 
            // colCourseId
            // 
            colCourseId.FillWeight = 7F;
            colCourseId.HeaderText = "ID khóa học";
            colCourseId.MinimumWidth = 6;
            colCourseId.Name = "colCourseId";
            colCourseId.ReadOnly = true;
            // 
            // colCourseCode
            // 
            colCourseCode.FillWeight = 8F;
            colCourseCode.HeaderText = "Mã khóa học";
            colCourseCode.MinimumWidth = 6;
            colCourseCode.Name = "colCourseCode";
            colCourseCode.ReadOnly = true;
            // 
            // colCourseName
            // 
            colCourseName.FillWeight = 20F;
            colCourseName.HeaderText = "Tên khóa học";
            colCourseName.MinimumWidth = 6;
            colCourseName.Name = "colCourseName";
            colCourseName.ReadOnly = true;
            // 
            // colTutitionFee
            // 
            colTutitionFee.FillWeight = 10F;
            colTutitionFee.HeaderText = "Học p[hí";
            colTutitionFee.MinimumWidth = 6;
            colTutitionFee.Name = "colTutitionFee";
            colTutitionFee.ReadOnly = true;
            // 
            // colNumberSession
            // 
            colNumberSession.FillWeight = 10F;
            colNumberSession.HeaderText = "Số buổi học";
            colNumberSession.MinimumWidth = 6;
            colNumberSession.Name = "colNumberSession";
            colNumberSession.ReadOnly = true;
            // 
            // colDescription
            // 
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            colDescription.DefaultCellStyle = dataGridViewCellStyle7;
            colDescription.FillWeight = 35F;
            colDescription.HeaderText = "Mô tả";
            colDescription.MinimumWidth = 6;
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;
            // 
            // colLevel
            // 
            colLevel.FillWeight = 10F;
            colLevel.HeaderText = "Cấp độ";
            colLevel.MinimumWidth = 6;
            colLevel.Name = "colLevel";
            colLevel.ReadOnly = true;
            // 
            // ManageCourse
            // 
            BackColor = Color.White;
            Controls.Add(dgvCourses);
            Controls.Add(panelActions);
            Controls.Add(panelHeader);
            Name = "ManageCourse";
            Size = new Size(1400, 800);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridViewTextBoxColumn colCourseId;
        private DataGridViewTextBoxColumn colCourseCode;
        private DataGridViewTextBoxColumn colCourseName;
        private DataGridViewTextBoxColumn colTutitionFee;
        private DataGridViewTextBoxColumn colNumberSession;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colLevel;
    }
}
