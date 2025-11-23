using BaiTapLon_WinFormApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Services.Interfaces
{
    public interface IStudentService
    {
        Student GetStudentById(int studentId);

        List<Class> GetRegisteredCourses(int studentId);

        List<Course> GetAvailableCourses(int studentId);
        bool UpdateStudent(int studentId, Student student);
        bool BuyCourse(int studentId, Course course, string payMethod);
    }
}
