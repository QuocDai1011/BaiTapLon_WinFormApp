using FontAwesome.Sharp;

namespace BaiTapLon_WinFormApp.Views.Admin.HomePageUI
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

        private Panel pnlDashboard;
        private PictureBox picDashboard;
        private Label lblDashboard;

        private Panel pnlMyClass;
        private PictureBox picMyClass;
        private Label lblMyClass;

        private Panel pnlStudentList;
        private PictureBox picStudentList;
        private Label lblStudentList;

        private Panel pnlCourse;
        private PictureBox picCourse;
        private Label lblCourse;

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
            pnlManagement = new Panel();
            lblManagement = new Label();
            picManagement = new PictureBox();
            pnlCourse = new Panel();
            lblCourse = new Label();
            picCourse = new PictureBox();
            pnlStudentList = new Panel();
            lblStudentList = new Label();
            picStudentList = new PictureBox();
            pnlMyClass = new Panel();
            lblMyClass = new Label();
            picMyClass = new PictureBox();
            pnlDashboard = new Panel();
            lblDashboard = new Label();
            picDashboard = new PictureBox();
            headerPanel = new Panel();
            label1 = new Label();
            logoBox = new PictureBox();
            contentPanel = new Panel();
            sidebarPanel.SuspendLayout();
            pnlManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picManagement).BeginInit();
            pnlCourse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCourse).BeginInit();
            pnlStudentList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picStudentList).BeginInit();
            pnlMyClass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMyClass).BeginInit();
            pnlDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDashboard).BeginInit();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.White;
            sidebarPanel.Controls.Add(pnlManagement);
            sidebarPanel.Controls.Add(pnlCourse);
            sidebarPanel.Controls.Add(pnlStudentList);
            sidebarPanel.Controls.Add(pnlMyClass);
            sidebarPanel.Controls.Add(pnlDashboard);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(280, 900);
            sidebarPanel.TabIndex = 0;
            // 
            // pnlManagement
            // 
            pnlManagement.BackColor = Color.White;
            pnlManagement.Controls.Add(lblManagement);
            pnlManagement.Controls.Add(picManagement);
            pnlManagement.Cursor = Cursors.Hand;
            pnlManagement.Location = new Point(10, 12);
            pnlManagement.Name = "pnlManagement";
            pnlManagement.Size = new Size(260, 55);
            pnlManagement.TabIndex = 7;
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
            // pnlCourse
            // 
            pnlCourse.BackColor = Color.White;
            pnlCourse.Controls.Add(lblCourse);
            pnlCourse.Controls.Add(picCourse);
            pnlCourse.Cursor = Cursors.Hand;
            pnlCourse.Location = new Point(10, 286);
            pnlCourse.Name = "pnlCourse";
            pnlCourse.Size = new Size(260, 55);
            pnlCourse.TabIndex = 5;
            pnlCourse.Click += Courses_Click;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Font = new Font("Segoe UI", 10F);
            lblCourse.ForeColor = Color.FromArgb(50, 50, 50);
            lblCourse.Location = new Point(60, 18);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(165, 23);
            lblCourse.TabIndex = 1;
            lblCourse.Text = "Danh sách khóa học";
            lblCourse.Click += Courses_Click;
            // 
            // picCourse
            // 
            picCourse.Image = Properties.Resources.EasyStore;
            picCourse.Location = new Point(15, 12);
            picCourse.Name = "picCourse";
            picCourse.Size = new Size(32, 32);
            picCourse.SizeMode = PictureBoxSizeMode.Zoom;
            picCourse.TabIndex = 0;
            picCourse.TabStop = false;
            picCourse.Click += Courses_Click;
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
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(label1);
            headerPanel.Controls.Add(logoBox);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(280, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1220, 80);
            headerPanel.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(145, 20);
            label1.Name = "label1";
            label1.Size = new Size(663, 41);
            label1.TabIndex = 11;
            label1.Text = "Hệ thống quản lý trung tâm anh ngữ Tre Xanh";
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
            pnlManagement.ResumeLayout(false);
            pnlManagement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picManagement).EndInit();
            pnlCourse.ResumeLayout(false);
            pnlCourse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picCourse).EndInit();
            pnlStudentList.ResumeLayout(false);
            pnlStudentList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picStudentList).EndInit();
            pnlMyClass.ResumeLayout(false);
            pnlMyClass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picMyClass).EndInit();
            pnlDashboard.ResumeLayout(false);
            pnlDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picDashboard).EndInit();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
        }
        private Label label1;
        private Panel pnlManagement;
        private Label lblManagement;
        private PictureBox picManagement;
    }
}