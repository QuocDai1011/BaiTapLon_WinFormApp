using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly EnglishCenterDbContext _context;

        public CourseRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }
        public string createCourse(Course newCourse)
        {
            try
            {
                _context.Courses.Add(newCourse);
                _context.SaveChanges();

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string deleteCourse(int courseId)
        {
            Course? course = getCourseById(courseId);
            if (course == null) return "Đã có lỗi xảy ra. Vui lòng thử lại!";
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return null;
        }

        public List<Course> getAllCourse()
        {
            try
            {
                return _context.Courses.ToList();
            }
            catch
            {
                return new List<Course>();
            }
        }

        public Course? getCourseById(int courseId)
        {
            try
            {
                return _context.Courses.FirstOrDefault(c => c.CourseId == courseId);
            }
            catch
            {
                return null;
            }
        }

        public string updateCourse(Course updatedCourse)
        {
            try
            {
                var existingCourse = _context.Courses.FirstOrDefault(c => c.CourseId == updatedCourse.CourseId);
                if (existingCourse == null)
                {
                    return "Course not found.";
                }
                existingCourse.CourseCode = updatedCourse.CourseCode;
                existingCourse.CourseName = updatedCourse.CourseName;
                existingCourse.TutitionFee = updatedCourse.TutitionFee;
                existingCourse.NumberSessions = updatedCourse.NumberSessions;
                existingCourse.Description = updatedCourse.Description;
                existingCourse.Level = updatedCourse.Level;
                existingCourse.UpdateAt = DateTime.Now;
                existingCourse.AvatarLink = updatedCourse.AvatarLink;
                _context.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
