using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLon_WinFormApp.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EnglishCenterDbContext _context;
        public StudentRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }

        public void AddReceipt(Receipt receipt)
        {
            _context.Receipts.Add(receipt);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public void AddStudentCourse(StudentCourse sc)
        {
            _context.StudentCourses.Add(sc);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public List<Course> GetAllCourse()
        {
            return _context.Courses.ToList();
        }

        public List<Course> GetAvailableCourse(int studentId)
        {
            var registerCourses = _context.StudentCourses
                .Where(r => r.StudentId == studentId)
                .Select(s => s.CourseId)
                .ToList();

            return _context.Courses
                .Where(c => !registerCourses.Contains(c.CourseId))
                .ToList();
        }

        public List<Class> GetRegisterCourse(int studentId)
        {
            return _context.Students
                .Where(s => s.StudentId == studentId)
                .SelectMany(c => c.Classes)
                .ToList();
        }

        public StudentCourse GetStudentCourse(int studentId, int courseId)
        {
            return _context.StudentCourses.FirstOrDefault(s => s.StudentId == studentId && s.CourseId == courseId);
        }

        public void UpdateById(int studentId, Student student)
        {
            var update = _context.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (update == null) return;

            update.FullName = student.FullName;
            update.Email = student.Email;
            update.Gender = student.Gender;
            update.DateOfBirth = student.DateOfBirth;
            update.PhoneNumber = student.PhoneNumber;
            update.PhoneNumberOfParents = student.PhoneNumberOfParents;
            update.Address = student.Address;

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public void UpdateReceipt(Receipt receipt)
        {
            _context.Receipts.Update(receipt);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public void AddStudentToClass(int studentId, int courseId)
        {
            var classOfCourse = _context.Classes
                .Include(cl => cl.Students)
                .FirstOrDefault(cl => cl.Courses.Any(c => c.CourseId == courseId));

            if (classOfCourse != null)
            {
                if (!classOfCourse.Students.Any(s => s.StudentId == studentId))
                {
                    var student = _context.Students.Find(studentId);
                    if (student == null)
                        throw new Exception("Student không tồn tại");

                    classOfCourse.Students.Add(student);
                    classOfCourse.CurrentStudent += 1;
                    _context.SaveChanges();
                }
            }
        }

        public string createStudent(Student student)
        {
            string errorMessage = "";
            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL duplicate key errors with friendly messages
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601)
                {
                    var lower = (sqlEx.GetBaseException()?.Message ?? sqlEx.Message).ToLowerInvariant();
                    if (lower.Contains("ix_students_user_name") || lower.Contains("user_name"))
                        errorMessage = "Tên đăng nhập đã tồn tại. Vui lòng dùng tên khác.";
                    else
                        errorMessage = "Lỗi: trùng khoá dữ liệu. Vui lòng kiểm tra dữ liệu nhập.";
                }
                else
                {
                    errorMessage = sqlEx.GetBaseException()?.Message ?? sqlEx.Message;
                }
            }
            catch (Exception ex)
            {
                var baseEx = ex.GetBaseException();
                // If inner is SqlException, handle duplicate key
                if (baseEx is SqlException innerSql && (innerSql.Number == 2627 || innerSql.Number == 2601))
                {
                    var lower = (innerSql.GetBaseException()?.Message ?? innerSql.Message).ToLowerInvariant();
                    if (lower.Contains("ix_students_user_name") || lower.Contains("user_name"))
                        errorMessage = "Tên đăng nhập đã tồn tại. Vui lòng dùng tên khác.";
                    else
                        errorMessage = "Lỗi: trùng khoá dữ liệu. Vui lòng kiểm tra dữ liệu nhập.";
                }
                else
                {
                    // Fallback to base exception message
                    errorMessage = baseEx?.Message ?? ex.Message;
                }
            }
            return errorMessage;
        }

        public string deleteStudent(int studentId)
        {
            string errorMessage = "";
            Student? student = getById(studentId);
            if (student != null)
            {
                try
                {
                    _context.Students.Remove(student);
                    _context.SaveChanges();
                }
                catch (SqlException sqlEx)
                {
                    errorMessage = sqlEx.GetBaseException()?.Message ?? sqlEx.Message;
                }
                catch (Exception ex)
                {
                    errorMessage = ex.GetBaseException()?.Message ?? ex.Message;
                }
            }
            return errorMessage;
        }

        public List<Student> getAllStudent()
        {
            string errorMessage = "";
            try
            {
                _context.Students.ToList();
                return _context.Students.ToList();
            }
            catch (SqlException sqlEx)
            {
                errorMessage = sqlEx.GetBaseException()?.Message ?? sqlEx.Message;
                return new List<Student>();
            }
            catch (Exception ex)
            {
                errorMessage = ex.GetBaseException()?.Message ?? ex.Message;
                return new List<Student>();
            }
        }

        public Student? getById(int studentId)
        {
            try
            {
                return _context.Students.Find(studentId);
            }
            catch (SqlException sqlEx)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Student? getStudentByEmail(string email)
        {
            try
            {
                return _context.Students.FirstOrDefault(t => t.Email == email);
            }
            catch (Exception sqlEx)
            {
                return null;
            }
        }

        public string updateStudent(Student student)
        {
            string errorMessage = "";
            try
            {
                _context.Students.Update(student);
                _context.SaveChanges();
            }
            catch (SqlException sqlEx)
            {
                errorMessage = sqlEx.GetBaseException()?.Message ?? sqlEx.Message;
            }
            catch (Exception ex)
            {
                errorMessage = ex.GetBaseException()?.Message ?? ex.Message;
            }
            return errorMessage;
        }

        public Course? getCourseById(int courseId)
        {
            try
            {
                return _context.Courses.Find(courseId);
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}