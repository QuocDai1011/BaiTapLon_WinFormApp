
using BaiTapLon_WinFormApp.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace BaiTapLon_WinFormApp
{
    public partial class Form1 : Form
    {
        public Form1(IStudentService studentService)
        {
            InitializeComponent();
           
        }
    }
}
