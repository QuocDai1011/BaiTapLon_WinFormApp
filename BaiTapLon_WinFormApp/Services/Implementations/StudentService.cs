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
        private readonly IStudentRepository _repo;
        private readonly EnglishCenterDbContext _context;

        public StudentService(IStudentRepository studentRepository, EnglishCenterDbContext context)
        {
            _studentRepository = studentRepository;
            _repo = studentRepository;
            _context = context;
        }

        public bool BuyCourse(int studentId, Course course, string payMethod)
        {
            if (_context == null)
                throw new Exception("_context chưa được khởi tạo");

            // Kiểm tra xem đã có StudentCourse chưa
            var sc = _repo.GetStudentCourse(studentId, course.CourseId);
            if (sc == null)
            {
                // Load entity Student và Course từ DB để EF biết principal
                var student = _context.Students.Find(studentId);
                var courseEntity = _context.Courses.Find(course.CourseId);

                if (student == null || courseEntity == null)
                    throw new Exception("Student hoặc Course không tồn tại trong DB");

                sc = new StudentCourse
                {
                    StudentId = studentId,
                    CourseId = course.CourseId,
                    DiscountType = "",
                    DiscountValue = 0,
                    CreateAt = DateTime.Now,
                    Student = student,
                    Course = courseEntity
                };

                _repo.AddStudentCourse(sc);
            }

            // Tạo Receipt
            var receipt = new Receipt
            {
                StudentId = studentId,
                CourseId = course.CourseId,
                Amount = course.TutitionFee - sc.DiscountValue,
                PaymentMethod = payMethod,
                Status = "Pending",
                PaymentDate = null,
                StudentCourse = sc
            };

            _repo.AddReceipt(receipt);

            // Thanh toán mô phỏng (mở browser)
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = $"https://fakepay.com/pay?studentId={studentId}&courseId={course.CourseId}&amount={receipt.Amount}",
                UseShellExecute = true
            });

            // Giả lập thanh toán thành công
            receipt.Status = "Paid";
            receipt.PaymentDate = DateTime.Now;
            _repo.UpdateReceipt(receipt);

            _repo.AddStudentToClass(studentId, course.CourseId);

            return true;
        }

        public List<Course> GetAvailableCourses(int studentId)
        {
            var student = _repo.GetById(studentId);
            if (student == null) throw new Exception("Không tìm thấy sinh viên");

            return _repo.GetAvailableCourse(studentId);
        }

        public string createStudent(Student student)
        {
            try
            {
                var errors = Validator.ValidateStudent(student);
                if (errors.Any())
                    return string.Join("\n", errors);

                //hash password bằng bcrypt trước khi thêm vào DB
                student.Password = BCrypt.Net.BCrypt.HashPassword(student.Password);

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

        public Student? getStudentByEmail(string email)
        {
            try
            {
                return _studentRepository.getStudentByEmail(email);
            }
            catch (Exception ex)
            {
                return null;
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

        public List<Class> GetRegisteredCourses(int studentId)
        {
            var registerCourses = _repo.GetById(studentId);
            if (registerCourses == null) throw new Exception("không tìm thấy sinh viên");

            return _repo.GetRegisterCourse(studentId);
        }

        public bool UpdateStudent(int studentId, Student student)
        {
            if (string.IsNullOrEmpty(student.FullName) ||
                string.IsNullOrEmpty(student.PhoneNumber) ||
                string.IsNullOrEmpty(student.PhoneNumberOfParents) ||
                string.IsNullOrEmpty(student.Address))
            {
                throw new Exception("Các trường dữ liệu bị trống");
            }

            _repo.UpdateById(studentId, student);
            return true;
        }
    }
}