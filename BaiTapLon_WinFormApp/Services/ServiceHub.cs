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
        public IClassService ClassService { get; }
        public ICourseService CourseService { get; }
        public ITeacherService TeacherService { get; }
        public ServiceHub(
            IClassService classService, 
            ICourseService courseService,
            ITeacherService teacherService
            )
        {
            ClassService = classService;
            CourseService = courseService;
            TeacherService = teacherService;
        }
    }
}
