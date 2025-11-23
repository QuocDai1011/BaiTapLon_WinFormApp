
using BaiTapLon_WinFormApp.Services.Interfaces;

namespace BaiTapLon_WinFormApp
{
    public partial class Form1 : Form
    {
        private readonly IStudentService _studentService;
        public Form1(IStudentService studentService)
        {
            InitializeComponent();
        }
    }
}
