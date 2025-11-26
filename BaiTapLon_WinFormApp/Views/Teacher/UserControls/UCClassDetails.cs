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

namespace BaiTapLon_WinFormApp.Views.Teacher.UserControls
{
    public partial class UCClassDetails : UserControl
    {

        private Panel _parentContainer;
        private readonly Class _class;
        private readonly Course _course;
        private readonly ServiceHub _serviceHub;
        private readonly int _teacherId;
        public UCClassDetails(
            Panel parentContainer, Class clazz, Course course,
            ServiceHub serviceHub, int teacherId
            )
        {
            _parentContainer = parentContainer;
            _class = clazz;
            _course = course;
            _serviceHub = serviceHub;
            _teacherId = teacherId;
            InitializeComponent();

            Render();
        }

        private void LoadUC(UserControl uc)
        {
            _parentContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            _parentContainer.Controls.Add(uc);
        }

        private void Render()
        {
            lblCourseCodeValue.Text = _course.CourseCode;
            lblCourseName.Text = _course.CourseName;
            lblNumberSessionValue.Text = _course.NumberSessions.ToString();
            lblLevelValue.Text = _course.Level;
            lblCreateAtValue.Text = _course.CreateAt?.ToString("dd/MM/yyyy");
            lblUpdateAtValue.Text = _course.UpdateAt?.ToString("dd/MM/yyyy");

            lblClassCode.Text = _class.ClassCode;
            lblClassName.Text = _class.ClassName;
            lblMaxStudentValue.Text = _class.MaxStudent.ToString();
            lblCurrentStudentValue.Text = _class.CurrentStudent.ToString();
            lblStartDateValue.Text = _class.StartDate.ToString("dd/MM/yyyy");
            lblEndDateValue.Text = _class.EndDate.ToString("dd/MM/yyyy");
            if (_class.Shift == 1)
            {
                lblShiftValue.Text = "8:00";
            }
            else if (_class.Shift == 2)
            {
                lblShiftValue.Text = "14:00";
            }
            else
            {
                lblShiftValue.Text = "18:00";
            }
            lblStatusValue.Text = _class.Status ? "Đang hoạt động" : "Đã kết thúc";
            if (_class.Status == false)
            {
                lblStatusValue.ForeColor = Color.Red;
            }
            else
            {
                lblStatusValue.ForeColor = Color.Green;
            }
            if (_class.OnlineMeetingLink == null || _class.OnlineMeetingLink == "NULL")
            {
                lblLinkValue.Text = "Khóa học này không có hình thức học trực tuyến";
            }
            else lblLinkValue.Text = _class.OnlineMeetingLink;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoadUC(new UCMyClass(_serviceHub, _teacherId, _parentContainer));
        }

        private void lblClassNameValue_Click(object sender, EventArgs e)
        {

        }

        private void lblHeadingClassDetail_Click(object sender, EventArgs e)
        {

        }
    }
}
