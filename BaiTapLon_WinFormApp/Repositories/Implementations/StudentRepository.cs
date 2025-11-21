using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EnglishCenterDbContext _context;

        public StudentRepository (EnglishCenterDbContext context)
        {
            _context = context;
        }

        public List<Student> getAll()
        {
               return _context.Students.ToList();
        }

        public string create()
        {
            try
            {
                _context.Students.Add(new Student
                {
                    FullName = "Nguyen Van A"
                });
            }
            catch (SqlException ex)
            {
                string inner = ex.InnerException != null ? ex.InnerException.Message : "";
                return inner;
            }
            return "";
        }
    }
}
