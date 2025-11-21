
using BaiTapLon_WinFormApp.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace BaiTapLon_WinFormApp
{
    public partial class Form1 : Form
    {
        private readonly IStudentService _studentService;
        public Form1(IStudentService studentService)
        {
            InitializeComponent();
            _studentService = studentService;

            var list = _studentService.getAll();

            string error = _studentService.create();

            MessageBox.Show("Số lượng học viên: " + list.Count);    
        }
    }
}
