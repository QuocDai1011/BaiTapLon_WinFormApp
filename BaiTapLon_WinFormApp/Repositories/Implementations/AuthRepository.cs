using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Repositories.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly EnglishCenterDbContext _context;

        public AuthRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }
        public string GetPasswordHashByEmail(string email, out string role)
        {
            role = null;
            var student = _context.Students.FirstOrDefault(s => s.Email == email);
            if (student != null)
            {
                role = "students";
                return student.Password;
            }
            var teacher = _context.Teachers.FirstOrDefault(t => t.Email == email);
            if (teacher != null)
            {
                role = "teachers";
                return teacher.Password;
            }
            var admin = _context.Admins.FirstOrDefault(a => a.Email == email);
            if (admin != null)
            {
                role = "admins";
                return admin.Password;
            }
            return null;
        }
        public bool EmailExists(string email)
        {
            return _context.Students.Any(s => s.Email == email) ||
                   _context.Teachers.Any(t => t.Email == email) ||
                   _context.Admins.Any(a => a.Email == email);
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public async Task<Student?> GetStudentByEmailAsync(string email)
        {
            return await _context.Students
                .FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
