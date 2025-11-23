using BaiTapLon_WinFormApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Repositories.Interfaces
{
   public interface IAuthRepository
    {
        string GetPasswordHashByEmail(string email, out string role);
        bool EmailExists(string email);
        void AddStudent(Student student);
        Task<Student?> GetStudentByEmailAsync(string email);
        Task UpdateStudentAsync(Student student);
    }
}
