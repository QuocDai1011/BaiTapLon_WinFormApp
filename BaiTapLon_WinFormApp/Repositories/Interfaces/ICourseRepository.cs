using BaiTapLon_WinFormApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Course GetCourseByClassId(int classId);
        List<Course> getAllCourse();

        Course? getCourseById(int courseId);

        string createCourse(Course newCourse);

        string updateCourse(Course updatedCourse);

        string deleteCourse(int courseId);

    }
}
