using BaiTapLon_WinFormApp.Models;
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
    public partial class UCCourseCard : UserControl
    {
        private readonly Class _class;
        private readonly Course _course;
        public UCCourseCard(Course course, Class clazz)
        {
            InitializeComponent();
            _course = course;
            _class = clazz;
            RenderCourse();
        }

        private void RenderCourse()
        {
            lblClassCode.Text = $"{_course.CourseCode}";
            lblNumberOfStudent.Text = $"{_class.CurrentStudent}/{_class.MaxStudent}";
            lblStartDate.Text = _class.StartDate.ToString("dd/MM/yyyy");
            lblEndate.Text = _class.EndDate.ToString("dd/MM/yyyy");
            if (_class.Shift == 1)
            {
                lblHours.Text = "8:00";
            }
            else if (_class.Shift == 2)
            {
                lblHours.Text = "14:00";
            }
            else
            {
                lblHours.Text = "18:00";
            }
            if (_class.Status == false)
            {
                lblStatusValue.Text = "Đã kết thúc";
                lblStatusValue.ForeColor = Color.Red;
            }
            else
            {
                lblStatusValue.Text = "Đang hoạt động";
            }
        }
    }
}
