using BaiTapLon_WinFormApp.Services.Implementations;
using BaiTapLon_WinFormApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Services
{
    public class ServiceHub
    {
        public IStudentService StudentService { get; }
        public IAuthService AuthService { get; }
        public IClassService ClassService { get; }
        public ServiceHub(
            IStudentService studentService,
            IAuthService authService,
            IClassService classService
            )
        {
            StudentService = studentService;
            AuthService = authService;
            ClassService = classService;
        }
    }
}
