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
        List<Student> getAllStudent();
        string createStudent(Student student);

        string updateStudent(Student student);

        string deleteStudent(int studentId);

        Student? GetStudentById(int studentId);

    }
}
