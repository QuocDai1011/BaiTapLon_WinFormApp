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
    public partial class UCMyClass : UserControl
    {
        private readonly Services.ServiceHub _serviceHub;
        private readonly int _teacherId;
        private Panel pnContentRender;

        public UCMyClass(Services.ServiceHub serviceHub, int teacherId, Panel flowLayoutPanel)
        {
            InitializeComponent();
            _serviceHub = serviceHub;
            _teacherId = teacherId;
            pnContentRender = flowLayoutPanel;
            LoadCourse();
        }

        private void LoadCourse()
        {
            pnContent.Controls.Clear();
            var classes = _serviceHub.ClassService.GetAllClassesByIdTeacher(_teacherId);
            if (classes == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu giảng viên.");
            }
            pnContent.FlowDirection = FlowDirection.LeftToRight;
            foreach (var c in classes)
            {
                try
                {
                    var course = _serviceHub.CourseService.GetCourseByIdClass(c.ClassId);
                    if (course == null)
                    {
                        continue;
                    }

                    var courseCard = new UCCourseCard(course, c, pnContentRender, _serviceHub, _teacherId);
                    pnContent.Controls.Add(courseCard);
                }
                catch(KeyNotFoundException ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
