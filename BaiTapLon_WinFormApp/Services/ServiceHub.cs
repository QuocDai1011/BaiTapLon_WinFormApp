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
        public IStudentService StudentService { get;  }
        public IClassService ClassService { get; }

        public ICourseService CourseService { get; }
        public ServiceHub(
            IStudentService studentService,
            IClassService classService,
            ICourseService courseService
            )
        {
            CourseService = courseService;
            StudentService = studentService;
            ClassService = classService;
        }
    }
}
