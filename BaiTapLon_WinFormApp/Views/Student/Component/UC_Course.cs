using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Services.Interfaces;
using System.Globalization;

namespace EnglishCenterManagement.UI.Views.Student.Component
{
    public partial class UC_Course : UserControl
    {
        private readonly IStudentService _studentService;
        private readonly EnglishCenterDbContext _context;
        private Course _course;
        private int _studentId;
        public UC_Course(int studentId, IStudentService studentService, EnglishCenterDbContext context)
        {
            InitializeComponent();
            _studentService = studentService;
            _context = context;
            _studentId = studentId;
        }

        public void LoadCourse(Course c)
        {
            _course = c;

            LabelNameCourse.Text = c.CourseName;
            LabelLession.Text = c.NumberSessions.ToString();
            LabelLevel.Text = c.Level;

            var vietnamese = new CultureInfo("vi-VN");
            LabelPrice.Text = c.TutitionFee.ToString("C0", vietnamese);
        }

        private void ButtonBuy_Click(object sender, EventArgs e)
        {
            if (_course == null) return;

            try
            {
                bool result = _studentService.BuyCourse(_studentId, _course, "Online");

                if(result)
                {
                    MessageBox.Show("Mua khóa học thành công");
                    ButtonBuy.Visible = false;
                }
                else
                {
                    MessageBox.Show("Mua khóa học thất bại");
                }

            } catch(Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
    }
}
