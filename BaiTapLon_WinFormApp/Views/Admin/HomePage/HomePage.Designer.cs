using FontAwesome.Sharp;

namespace BaiTapLon_WinFormApp.Views.Admin.HomePage
{
    partial class HomePage
    {
        private System.ComponentModel.IContainer components = null;

        // Main Panels
        private Panel sidebarPanel;
        private Panel headerPanel;
        private Panel contentPanel;

        // Header Components
        private PictureBox logoBox;
        private IconButton btnPlus;
        private IconButton btnProfile;

        // Sidebar Components
        private Panel pnlManagement;
        private PictureBox picManagement;
        private Label lblManagement;

        private Panel pnlDashboard;
        private PictureBox picDashboard;
        private Label lblDashboard;

        private Panel pnlMyClass;
        private PictureBox picMyClass;
        private Label lblMyClass;

        private Panel pnlStudentList;
        private PictureBox picStudentList;
        private Label lblStudentList;

        private Label lblShortcuts;

        private Panel pnlCalendar;
        private PictureBox picCalendar;
        private Label lblCalendar;

        private Panel pnlInvoice;
        private PictureBox picInvoice;
        private Label lblInvoice;

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
            sidebarPanel = new Panel();
            pnlInvoice = new Panel();
            lblInvoice = new Label();
            picInvoice = new PictureBox();
            pnlCalendar = new Panel();
            lblCalendar = new Label();
            picCalendar = new PictureBox();
            lblShortcuts = new Label();
            pnlStudentList = new Panel();
            lblStudentList = new Label();
            picStudentList = new PictureBox();
            pnlMyClass = new Panel();
            lblMyClass = new Label();
            picMyClass = new PictureBox();
            pnlDashboard = new Panel();
            lblDashboard = new Label();
            picDashboard = new PictureBox();
            pnlManagement = new Panel();
            lblManagement = new Label();
            picManagement = new PictureBox();
            headerPanel = new Panel();
            btnProfile = new IconButton();
            btnPlus = new IconButton();
            logoBox = new PictureBox();
            contentPanel = new Panel();
            label1 = new Label();
            sidebarPanel.SuspendLayout();
            pnlInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picInvoice).BeginInit();
            pnlCalendar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCalendar).BeginInit();
            pnlStudentList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picStudentList).BeginInit();
            pnlMyClass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMyClass).BeginInit();
            pnlDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDashboard).BeginInit();
            pnlManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picManagement).BeginInit();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.White;
            sidebarPanel.Controls.Add(pnlInvoice);
            sidebarPanel.Controls.Add(pnlCalendar);
            sidebarPanel.Controls.Add(lblShortcuts);
            sidebarPanel.Controls.Add(pnlStudentList);
            sidebarPanel.Controls.Add(pnlMyClass);
            sidebarPanel.Controls.Add(pnlDashboard);
            sidebarPanel.Controls.Add(pnlManagement);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(280, 900);
            sidebarPanel.TabIndex = 0;
            // 
            // pnlInvoice
            // 
            pnlInvoice.BackColor = Color.White;
            pnlInvoice.Controls.Add(lblInvoice);
            pnlInvoice.Controls.Add(picInvoice);
            pnlInvoice.Cursor = Cursors.Hand;
            pnlInvoice.Location = new Point(10, 395);
            pnlInvoice.Name = "pnlInvoice";
            pnlInvoice.Size = new Size(260, 55);
            pnlInvoice.TabIndex = 6;
            pnlInvoice.Click += invoice_Click;
            // 
            // lblInvoice
            // 
            lblInvoice.AutoSize = true;
            lblInvoice.Font = new Font("Segoe UI", 10F);
            lblInvoice.ForeColor = Color.FromArgb(50, 50, 50);
            lblInvoice.Location = new Point(60, 18);
            lblInvoice.Name = "lblInvoice";
            lblInvoice.Size = new Size(76, 23);
            lblInvoice.TabIndex = 1;
            lblInvoice.Text = "Hóa đơn";
            lblInvoice.Click += invoice_Click;
            // 
            // picInvoice
            // 
            picInvoice.Image = Properties.Resources.Receipt;
            picInvoice.Location = new Point(15, 12);
            picInvoice.Name = "picInvoice";
            picInvoice.Size = new Size(32, 32);
            picInvoice.SizeMode = PictureBoxSizeMode.Zoom;
            picInvoice.TabIndex = 0;
            picInvoice.TabStop = false;
            picInvoice.Click += invoice_Click;
            // 
            // pnlCalendar
            // 
            pnlCalendar.BackColor = Color.White;
            pnlCalendar.Controls.Add(lblCalendar);
            pnlCalendar.Controls.Add(picCalendar);
            pnlCalendar.Cursor = Cursors.Hand;
            pnlCalendar.Location = new Point(10, 330);
            pnlCalendar.Name = "pnlCalendar";
            pnlCalendar.Size = new Size(260, 55);
            pnlCalendar.TabIndex = 5;
            pnlCalendar.Click += calendar_Click;
            // 
            // lblCalendar
            // 
            lblCalendar.AutoSize = true;
            lblCalendar.Font = new Font("Segoe UI", 10F);
            lblCalendar.ForeColor = Color.FromArgb(50, 50, 50);
            lblCalendar.Location = new Point(60, 18);
            lblCalendar.Name = "lblCalendar";
            lblCalendar.Size = new Size(106, 23);
            lblCalendar.TabIndex = 1;
            lblCalendar.Text = "Lịch cá nhân";
            lblCalendar.Click += calendar_Click;
            // 
            // picCalendar
            // 
            picCalendar.Image = Properties.Resources.myCalendar;
            picCalendar.Location = new Point(15, 12);
            picCalendar.Name = "picCalendar";
            picCalendar.Size = new Size(32, 32);
            picCalendar.SizeMode = PictureBoxSizeMode.Zoom;
            picCalendar.TabIndex = 0;
            picCalendar.TabStop = false;
            picCalendar.Click += calendar_Click;
            // 
            // lblShortcuts
            // 
            lblShortcuts.AutoSize = true;
            lblShortcuts.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblShortcuts.ForeColor = Color.Gray;
            lblShortcuts.Location = new Point(25, 295);
            lblShortcuts.Name = "lblShortcuts";
            lblShortcuts.Size = new Size(112, 20);
            lblShortcuts.TabIndex = 4;
            lblShortcuts.Text = "Lối tắt của bạn";
            // 
            // pnlStudentList
            // 
            pnlStudentList.BackColor = Color.White;
            pnlStudentList.Controls.Add(lblStudentList);
            pnlStudentList.Controls.Add(picStudentList);
            pnlStudentList.Cursor = Cursors.Hand;
            pnlStudentList.Location = new Point(10, 215);
            pnlStudentList.Name = "pnlStudentList";
            pnlStudentList.Size = new Size(260, 55);
            pnlStudentList.TabIndex = 3;
            pnlStudentList.Click += studentManagement_Click;
            // 
            // lblStudentList
            // 
            lblStudentList.AutoSize = true;
            lblStudentList.Font = new Font("Segoe UI", 10F);
            lblStudentList.ForeColor = Color.FromArgb(50, 50, 50);
            lblStudentList.Location = new Point(60, 18);
            lblStudentList.Name = "lblStudentList";
            lblStudentList.Size = new Size(162, 23);
            lblStudentList.TabIndex = 1;
            lblStudentList.Text = "Danh sách sinh viên";
            lblStudentList.Click += studentManagement_Click;
            // 
            // picStudentList
            // 
            picStudentList.Image = Properties.Resources.group;
            picStudentList.Location = new Point(15, 12);
            picStudentList.Name = "picStudentList";
            picStudentList.Size = new Size(32, 32);
            picStudentList.SizeMode = PictureBoxSizeMode.Zoom;
            picStudentList.TabIndex = 0;
            picStudentList.TabStop = false;
            picStudentList.Click += studentManagement_Click;
            // 
            // pnlMyClass
            // 
            pnlMyClass.BackColor = Color.White;
            pnlMyClass.Controls.Add(lblMyClass);
            pnlMyClass.Controls.Add(picMyClass);
            pnlMyClass.Cursor = Cursors.Hand;
            pnlMyClass.Location = new Point(10, 150);
            pnlMyClass.Name = "pnlMyClass";
            pnlMyClass.Size = new Size(260, 55);
            pnlMyClass.TabIndex = 2;
            pnlMyClass.Click += myClass_Click;
            // 
            // lblMyClass
            // 
            lblMyClass.AutoSize = true;
            lblMyClass.Font = new Font("Segoe UI", 10F);
            lblMyClass.ForeColor = Color.FromArgb(50, 50, 50);
            lblMyClass.Location = new Point(60, 18);
            lblMyClass.Name = "lblMyClass";
            lblMyClass.Size = new Size(128, 23);
            lblMyClass.TabIndex = 1;
            lblMyClass.Text = "Lớp học của tôi";
            lblMyClass.Click += myClass_Click;
            // 
            // picMyClass
            // 
            picMyClass.Image = Properties.Resources.myClass;
            picMyClass.Location = new Point(15, 12);
            picMyClass.Name = "picMyClass";
            picMyClass.Size = new Size(32, 32);
            picMyClass.SizeMode = PictureBoxSizeMode.Zoom;
            picMyClass.TabIndex = 0;
            picMyClass.TabStop = false;
            picMyClass.Click += myClass_Click;
            // 
            // pnlDashboard
            // 
            pnlDashboard.BackColor = Color.FromArgb(240, 245, 255);
            pnlDashboard.Controls.Add(lblDashboard);
            pnlDashboard.Controls.Add(picDashboard);
            pnlDashboard.Cursor = Cursors.Hand;
            pnlDashboard.Location = new Point(10, 85);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(260, 55);
            pnlDashboard.TabIndex = 1;
            pnlDashboard.Click += dashboard_Click;
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.Font = new Font("Segoe UI", 10F);
            lblDashboard.ForeColor = Color.FromArgb(50, 50, 50);
            lblDashboard.Location = new Point(60, 18);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(93, 23);
            lblDashboard.TabIndex = 1;
            lblDashboard.Text = "Dashboard";
            lblDashboard.Click += dashboard_Click;
            // 
            // picDashboard
            // 
            picDashboard.Image = Properties.Resources.logo2019_png_1;
            picDashboard.Location = new Point(15, 12);
            picDashboard.Name = "picDashboard";
            picDashboard.Size = new Size(32, 32);
            picDashboard.SizeMode = PictureBoxSizeMode.Zoom;
            picDashboard.TabIndex = 0;
            picDashboard.TabStop = false;
            picDashboard.Click += dashboard_Click;
            // 
            // pnlManagement
            // 
            pnlManagement.BackColor = Color.White;
            pnlManagement.Controls.Add(lblManagement);
            pnlManagement.Controls.Add(picManagement);
            pnlManagement.Cursor = Cursors.Hand;
            pnlManagement.Location = new Point(10, 20);
            pnlManagement.Name = "pnlManagement";
            pnlManagement.Size = new Size(260, 55);
            pnlManagement.TabIndex = 0;
            pnlManagement.Click += management_Click;
            // 
            // lblManagement
            // 
            lblManagement.AutoSize = true;
            lblManagement.Font = new Font("Segoe UI", 10F);
            lblManagement.ForeColor = Color.FromArgb(50, 50, 50);
            lblManagement.Location = new Point(60, 18);
            lblManagement.Name = "lblManagement";
            lblManagement.Size = new Size(72, 23);
            lblManagement.TabIndex = 1;
            lblManagement.Text = "Quản Lý";
            lblManagement.Click += management_Click;
            // 
            // picManagement
            // 
            picManagement.Image = Properties.Resources.logo2019_png_1;
            picManagement.Location = new Point(15, 12);
            picManagement.Name = "picManagement";
            picManagement.Size = new Size(32, 32);
            picManagement.SizeMode = PictureBoxSizeMode.Zoom;
            picManagement.TabIndex = 0;
            picManagement.TabStop = false;
            picManagement.Click += management_Click;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(label1);
            headerPanel.Controls.Add(btnProfile);
            headerPanel.Controls.Add(btnPlus);
            headerPanel.Controls.Add(logoBox);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(280, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1220, 80);
            headerPanel.TabIndex = 1;
            // 
            // btnProfile
            // 
            btnProfile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnProfile.BackColor = Color.FromArgb(228, 230, 235);
            btnProfile.Cursor = Cursors.Hand;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.IconChar = IconChar.CaretDown;
            btnProfile.IconColor = Color.FromArgb(65, 65, 65);
            btnProfile.IconFont = IconFont.Auto;
            btnProfile.IconSize = 24;
            btnProfile.Location = new Point(1138, 3);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(70, 70);
            btnProfile.TabIndex = 10;
            btnProfile.UseVisualStyleBackColor = false;
            // 
            // btnPlus
            // 
            btnPlus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPlus.BackColor = Color.FromArgb(228, 230, 235);
            btnPlus.Cursor = Cursors.Hand;
            btnPlus.FlatAppearance.BorderSize = 0;
            btnPlus.FlatStyle = FlatStyle.Flat;
            btnPlus.IconChar = IconChar.Add;
            btnPlus.IconColor = Color.FromArgb(65, 65, 65);
            btnPlus.IconFont = IconFont.Auto;
            btnPlus.IconSize = 24;
            btnPlus.Location = new Point(1033, 3);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(70, 70);
            btnPlus.TabIndex = 6;
            btnPlus.UseVisualStyleBackColor = false;
            // 
            // logoBox
            // 
            logoBox.Image = Properties.Resources.logo2019_png_1;
            logoBox.Location = new Point(20, 5);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(70, 70);
            logoBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoBox.TabIndex = 0;
            logoBox.TabStop = false;
            // 
            // contentPanel
            // 
            contentPanel.AutoScroll = true;
            contentPanel.BackColor = Color.FromArgb(245, 247, 250);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(280, 80);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(30);
            contentPanel.Size = new Size(1220, 820);
            contentPanel.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(145, 20);
            label1.Name = "label1";
            label1.Size = new Size(663, 41);
            label1.TabIndex = 11;
            label1.Text = "Hệ thống quản lý trung tâm anh ngữ Tre Xanh";
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1500, 900);
            Controls.Add(contentPanel);
            Controls.Add(headerPanel);
            Controls.Add(sidebarPanel);
            Name = "HomePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tennis Social Network";
            WindowState = FormWindowState.Maximized;
            sidebarPanel.ResumeLayout(false);
            sidebarPanel.PerformLayout();
            pnlInvoice.ResumeLayout(false);
            pnlInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picInvoice).EndInit();
            pnlCalendar.ResumeLayout(false);
            pnlCalendar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picCalendar).EndInit();
            pnlStudentList.ResumeLayout(false);
            pnlStudentList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picStudentList).EndInit();
            pnlMyClass.ResumeLayout(false);
            pnlMyClass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picMyClass).EndInit();
            pnlDashboard.ResumeLayout(false);
            pnlDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picDashboard).EndInit();
            pnlManagement.ResumeLayout(false);
            pnlManagement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picManagement).EndInit();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
        }
        private Label label1;
    }
}