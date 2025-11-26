using BaiTapLon_WinFormApp.Views.SystemAcess.Login;
using BaiTapLon_WinFormApp.Views.Teacher.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace BaiTapLon_WinFormApp.Views.Teacher
{
    public partial class TeacherMainForm : Form
    {
        private readonly Services.ServiceHub _serviceHub;
        private readonly int _teacherId;

        public TeacherMainForm(Services.ServiceHub serviceHub, int teacherId)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _teacherId = teacherId;

            SetTeacherName();
            LoadUC(new UCProfile(_teacherId, _serviceHub));
            AddClickEventToAllControls(this);
        }

        public void SetTeacherName()
        {
            try
            {
                var teacher = _serviceHub.TeacherService.GetTeacherById(_teacherId);
                lblNameHeader.Text = teacher.FullName.Split(' ').Last();
                btnProfileSideBar.Text = teacher.FullName;
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUC(UserControl uc)
        {
            pnContentRender.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnContentRender.Controls.Add(uc);
            AddClickEventToAllControls(this);
        }

        private void TeacherMainForm_Load(object sender, EventArgs e)
        {
            AddClickEventToAllControls(this);
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnProfileSideBar_Click(object sender, EventArgs e)
        {
            LoadUC(new UCProfile(_teacherId, _serviceHub));
        }

        private void btnMyClassSideBar_Click(object sender, EventArgs e)
        {
            LoadUC(new UCMyClass(_serviceHub, _teacherId, pnContentRender));
        }

        private void btnClassHeader_Click(object sender, EventArgs e)
        {
            LoadUC(new UCMyClass(_serviceHub, _teacherId, pnContentRender));
        }

        private void btnHomeHeader_Click(object sender, EventArgs e)
        {
            LoadUC(new UCProfile(_teacherId, _serviceHub));
        }

        private void btnDropDownHeader_Click(object sender, EventArgs e)
        {
            pnDropDown.Visible = !pnDropDown.Visible;
            pnDropDown.BringToFront();

            // Lấy tọa độ tuyệt đối của nút
            Point locationOnForm = btnDropDownHeader.Parent.PointToScreen(btnDropDownHeader.Location);
            locationOnForm = this.PointToClient(locationOnForm);

            pnDropDown.Location = new Point(
                locationOnForm.X + btnDropDownHeader.Width - pnDropDown.Width,
                locationOnForm.Y + btnDropDownHeader.Height + 20
            );

            pnDropDown.BackColor = Color.Transparent; // KHÔNG transparent

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void AddClickEventToAllControls(Control control)
        {
            control.Click += HideDropDown;

            foreach (Control child in control.Controls)
            {
                AddClickEventToAllControls(child);
            }
        }

        private void HideDropDown(object sender, EventArgs e)
        {
            // Nếu không phải click vào chính dropdown hoặc nút mở dropdown
            if (sender != pnDropDown && sender != btnDropDownHeader)
            {
                pnDropDown.Visible = false;
            }
        }

        private void btnProfileDropDown_Click(object sender, EventArgs e)
        {
            LoadUC(new UCProfile(_teacherId, _serviceHub));
        }

        private void btnLogOutDropDown_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

            if (rs == DialogResult.Yes)
            {
                this.Dispose();
                new LoginForm(_serviceHub).ShowDialog();
            }
        }

        private void pnProfileHeader_Paint(object sender, PaintEventArgs e)
        {
            LoadUC(new UCProfile(_teacherId, _serviceHub));
        }

    }
}
