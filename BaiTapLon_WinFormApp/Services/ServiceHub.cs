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
        public ServiceHub(
            IStudentService studentService,
            IAuthService authService
            )
        {
            StudentService = studentService;
            AuthService = authService;
        }
    }
}