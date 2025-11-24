namespace BaiTapLon_WinFormApp.Views.Admin.MyClassUI
{
    partial class AddStudentsToClassForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnClose;
        private Panel pnlMain;
        private Panel pnlSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private CheckBox chkSelectAll;
        private Panel pnlStudentList;
        private CheckedListBox clbStudents;
        private Panel pnlFooter;
        private Label lblSelectedCount;
        private Button btnCancel;
        private Button btnAdd;

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
            pnlStudentList = new Panel();
            clbStudents = new CheckedListBox();
            pnlSearch = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            chkSelectAll = new CheckBox();
            pnlFooter = new Panel();
            lblSelectedCount = new Label();
            btnCancel = new Button();
            btnAdd = new Button();
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlStudentList.SuspendLayout();
            pnlSearch.SuspendLayout();
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
            pnlHeader.Size = new Size(700, 60);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(622, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Thêm Học Viên Vào Lớp";
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
            btnClose.Location = new Point(648, 10);
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
            pnlMain.Controls.Add(pnlStudentList);
            pnlMain.Controls.Add(pnlSearch);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(20);
            pnlMain.Size = new Size(700, 483);
            pnlMain.TabIndex = 0;
            // 
            // pnlStudentList
            // 
            pnlStudentList.BackColor = Color.White;
            pnlStudentList.Controls.Add(clbStudents);
            pnlStudentList.Dock = DockStyle.Fill;
            pnlStudentList.Location = new Point(20, 140);
            pnlStudentList.Name = "pnlStudentList";
            pnlStudentList.Padding = new Padding(20);
            pnlStudentList.Size = new Size(660, 323);
            pnlStudentList.TabIndex = 0;
            // 
            // clbStudents
            // 
            clbStudents.BackColor = Color.White;
            clbStudents.BorderStyle = BorderStyle.FixedSingle;
            clbStudents.CheckOnClick = true;
            clbStudents.Dock = DockStyle.Fill;
            clbStudents.Font = new Font("Segoe UI", 10F);
            clbStudents.IntegralHeight = false;
            clbStudents.Location = new Point(20, 20);
            clbStudents.Name = "clbStudents";
            clbStudents.Size = new Size(620, 283);
            clbStudents.TabIndex = 0;
            clbStudents.ItemCheck += clbStudents_ItemCheck;
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.White;
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(chkSelectAll);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(20, 20);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Padding = new Padding(20);
            pnlSearch.Size = new Size(660, 120);
            pnlSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(20, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔍 Tìm kiếm theo mã hoặc tên học viên...";
            txtSearch.Size = new Size(450, 32);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(0, 120, 212);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(480, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 32);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            btnSearch.MouseEnter += BtnSearch_MouseEnter;
            btnSearch.MouseLeave += BtnSearch_MouseLeave;
            // 
            // chkSelectAll
            // 
            chkSelectAll.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkSelectAll.ForeColor = Color.FromArgb(33, 33, 33);
            chkSelectAll.Location = new Point(20, 70);
            chkSelectAll.Name = "chkSelectAll";
            chkSelectAll.Size = new Size(200, 30);
            chkSelectAll.TabIndex = 2;
            chkSelectAll.Text = "Chọn tất cả";
            chkSelectAll.CheckedChanged += chkSelectAll_CheckedChanged;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.White;
            pnlFooter.Controls.Add(lblSelectedCount);
            pnlFooter.Controls.Add(btnCancel);
            pnlFooter.Controls.Add(btnAdd);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 543);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Padding = new Padding(20);
            pnlFooter.Size = new Size(700, 119);
            pnlFooter.TabIndex = 1;
            // 
            // lblSelectedCount
            // 
            lblSelectedCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSelectedCount.ForeColor = Color.FromArgb(0, 120, 212);
            lblSelectedCount.Location = new Point(20, 42);
            lblSelectedCount.Name = "lblSelectedCount";
            lblSelectedCount.Size = new Size(300, 35);
            lblSelectedCount.TabIndex = 0;
            lblSelectedCount.Text = "Đã chọn: 0 học viên";
            lblSelectedCount.TextAlign = ContentAlignment.MiddleLeft;
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
            btnCancel.Location = new Point(550, 36);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 45);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnClose_Click;
            btnCancel.MouseEnter += BtnCancel_MouseEnter;
            btnCancel.MouseLeave += BtnCancel_MouseLeave;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdd.BackColor = Color.FromArgb(40, 167, 69);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(364, 36);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(169, 45);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Thêm học viên";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            btnAdd.MouseEnter += BtnAdd_MouseEnter;
            btnAdd.MouseLeave += BtnAdd_MouseLeave;
            // 
            // AddStudentsToClassForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(700, 662);
            Controls.Add(pnlMain);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddStudentsToClassForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm Học Viên";
            pnlHeader.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlStudentList.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        // Hover effects
        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(192, 0, 0);
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Transparent;
        }

        private void BtnSearch_MouseEnter(object sender, EventArgs e)
        {
            btnSearch.BackColor = Color.FromArgb(0, 100, 190);
        }

        private void BtnSearch_MouseLeave(object sender, EventArgs e)
        {
            btnSearch.BackColor = Color.FromArgb(0, 120, 212);
        }

        private void BtnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(210, 210, 210);
        }

        private void BtnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = Color.FromArgb(230, 230, 230);
        }

        private void BtnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.FromArgb(33, 136, 56);
        }

        private void BtnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.FromArgb(40, 167, 69);
        }
    }
}