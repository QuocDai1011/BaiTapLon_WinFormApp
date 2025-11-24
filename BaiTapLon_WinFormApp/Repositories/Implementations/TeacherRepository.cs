using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Repositories.Implementations
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly EnglishCenterDbContext _context;

        public TeacherRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }

        public Teacher? getTeacherByEmail(string email)
        {
            try
            {
                return _context.Teachers.FirstOrDefault(t => t.Email == email);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Teacher GetTeacherById(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null)
            {
                throw new KeyNotFoundException("Không tìm thấy dữ liệu giảng viên.");
            }
            return teacher;
        }

        public int UpdateProfile(int id, Teacher teacherUpdated)
        {
            var teacherTemp = _context.Teachers.Find(id);
            if (teacherTemp == null)
            {
                return 0;
            }

            // Cập nhật thời gian sửa
            teacherTemp.UpdateAt = DateOnly.FromDateTime(DateTime.Now);

            // Copy các giá trị từ teacher (trừ Id)
            _context.Entry(teacherTemp).CurrentValues.SetValues(teacherUpdated);

            // Lưu thay đổi (dùng đồng bộ nếu hàm không async)
            _context.SaveChanges();

            return 1;
        }
    }
}
