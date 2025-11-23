using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Repositories.Interfaces;
using BaiTapLon_WinFormApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        private readonly EnglishCenterDbContext _context;

        public StudentService(IStudentRepository repo, EnglishCenterDbContext context)
        {
            _repo = repo;
            _context = context;
        }


        public bool BuyCourse(int studentId, Course course, string payMethod)
        {
            if (_context == null)
                throw new Exception("_context chưa được khởi tạo");  // kiểm tra an toàn
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

                _repo.AddStudentCourse(sc);  // Lưu vào DB
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

        public List<Class> GetRegisteredCourses(int studentId)
        {
            var registerCourses = _repo.GetById(studentId);
            if (registerCourses == null) throw new Exception("không tìm thấy sinh viên");

            return _repo.GetRegisterCourse(studentId);
        }

        public Student GetStudentById(int studentId)
        {
            var student = _repo.GetById(studentId);
            if (student == null) throw new Exception("Không tìm thấy sinh viên");

            return student;
        }
        public bool UpdateStudent(int studentId, Student student)
        {
            if(string.IsNullOrEmpty(student.FullName) ||
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
