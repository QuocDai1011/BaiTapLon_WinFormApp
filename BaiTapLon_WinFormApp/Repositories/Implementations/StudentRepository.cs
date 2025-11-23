using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Repositories.Interfaces;
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

        public Student GetById(int studentId)
        {
            return _context.Students.FirstOrDefault(c => c.StudentId == studentId);
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
    }
}
