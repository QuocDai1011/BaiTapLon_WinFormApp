using BaiTapLon_WinFormApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Student GetById(int studentId);
        List<Class> GetRegisterCourse(int studentId);
        List<Course> GetAvailableCourse(int studentId);
        void UpdateById(int studentId, Student student);
        StudentCourse GetStudentCourse(int studentId, int courseId);
        void AddStudentCourse(StudentCourse sc);
        void AddReceipt(Receipt receipt);
        void UpdateReceipt(Receipt receipt);
        List<Course> GetAllCourse();
        void AddStudentToClass(int studentId, int courseId);
    }
}
