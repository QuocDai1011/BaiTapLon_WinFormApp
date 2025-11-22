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

        public Course GetCourseByClassId(int classId)
        {
            var course = _context.Classes
                .Where(c => c.ClassId == classId)
                .SelectMany(c => c.Courses)
                .FirstOrDefault();

            if (course == null)
            {
                throw new KeyNotFoundException("Không tìm thấy dữ liệu khóa học.");
            }
            return course;
        }
    }
}
