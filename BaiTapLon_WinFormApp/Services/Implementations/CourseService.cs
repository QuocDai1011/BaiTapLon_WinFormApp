using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Repositories.Interfaces;
using BaiTapLon_WinFormApp.Services.Interfaces;
using BaiTapLon_WinFormApp.Utils;
using System;
using System.Collections.Generic;

namespace BaiTapLon_WinFormApp.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Course GetCourseByIdClass(int classId)
        {
            return _courseRepository.GetCourseByClassId(classId);
        }

        public string createCourse(Course newCourse)
        {
            List<string> error = Validator.ValidateCourse(newCourse);

            if (error.Count > 0)
            {
                return string.Join("\n", error);
            }

            var repoResult = _courseRepository.createCourse(newCourse);
            return string.IsNullOrEmpty(repoResult) ? null : repoResult;
        }

        public string deleteCourse(int courseId)
        {
            if (courseId <= 0)
            {
                return "Mã khóa học không hợp lệ!";
            }
            return _courseRepository.deleteCourse(courseId);
        }

        public List<Course> getAllCourse()
        {
            return _courseRepository.getAllCourse();
        }

        public Course? getCourseById(int courseId)
        {
            if (courseId <= 0) return null;
            return _courseRepository.getCourseById(courseId);
        }

        public string updateCourse(Course updatedCourse)
        {
            List<string> error = Validator.ValidateCourse(updatedCourse);

            if (error.Count > 0)
            {
                return string.Join("\n", error);
            }

            var repoResult = _courseRepository.updateCourse(updatedCourse);
            return string.IsNullOrEmpty(repoResult) ? null : repoResult;
        }
    }
}
