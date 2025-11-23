using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Repositories.Interfaces;
using BaiTapLon_WinFormApp.Services.Interfaces;
using BaiTapLon_WinFormApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;

        }

        public string createStudent(Student student)
        {
            try
            {
                var errors = Validator.ValidateStudent(student);
                if (errors.Any())
                    return string.Join("\n", errors);

                // Thêm học sinh vào DB
                var repoResult = _studentRepository.createStudent(student);
                // Repository returns empty string on success, or an error message
                return string.IsNullOrEmpty(repoResult) ? null : repoResult;
            }
            catch (Exception ex)
            {
                return "Hệ thống gặp sự cố. Vui lòng liên hệ quản trị viên";
            }
        }

        public string deleteStudent(int studentId)
        {

            string errorMessage = "";
            Student? student = GetStudentById(studentId);
            if (student != null)
            {
                try
                {
                    errorMessage = _studentRepository.deleteStudent(studentId);
                    if (string.IsNullOrEmpty(errorMessage))
                        errorMessage = "Xóa học sinh thành công.";
                }
                catch (Exception ex)
                {
                    errorMessage = "Hệ thống gặp sự cố. Vui lòng liên hệ quản trị viên";
                }
            }
            return errorMessage;
        }

        public List<Student> getAllStudent()
        {
            try
            {
                return _studentRepository.getAllStudent();
            }
            catch (Exception ex)
            {
                return new List<Student>();
            }
        }

        public Student? GetStudentById(int studentId)
        {
            
            try
            {
                return _studentRepository.getById(studentId);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public string updateStudent(Student student)
        {
            try
            {
                var errors = Validator.ValidateStudent(student);
                if (errors.Any())
                    return string.Join("\n", errors);
                // Cập nhật học sinh trong DB
                var repoResult = _studentRepository.updateStudent(student);
                return string.IsNullOrEmpty(repoResult) ? null : repoResult;
            }
            catch (Exception ex)
            {
                return "Hệ thống gặp sự cố. Vui lòng liên hệ quản trị viên";
            }
        }
    }
}
