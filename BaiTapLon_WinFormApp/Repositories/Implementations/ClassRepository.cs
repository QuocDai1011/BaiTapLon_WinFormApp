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
    public class ClassRepository : IClassRepository
    {
        private readonly EnglishCenterDbContext _context;

        public ClassRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }

        public List<Class> GetAllClassesByIdTeacher(int teacherId)
        {
            var classes = _context.Teachers
                .Where(t => t.AdminId == teacherId)
                .SelectMany(t => t.Classes)
                .ToList();

            return classes;
        }

        public string AddStudentsToClass(int classId, List<int> studentIds)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                // Lấy class entity với Students navigation
                var classEntity = _context.Classes
                    .Include(c => c.Students)
                    .FirstOrDefault(c => c.ClassId == classId);

                if (classEntity == null)
                {
                    return "Lớp học không tồn tại.";
                }

                // Lấy tất cả student entities
                var studentEntities = _context.Students
                    .Where(s => studentIds.Contains(s.StudentId))
                    .ToList();

                if (studentEntities.Count != studentIds.Count)
                {
                    var foundIds = studentEntities.Select(s => s.StudentId).ToList();
                    var missingIds = studentIds.Except(foundIds).ToList();
                    return $"Không tìm thấy các học viên: {string.Join(", ", missingIds)}";
                }

                // Thêm từng học viên vào lớp
                foreach (var student in studentEntities)
                {
                    // Kiểm tra xem học viên đã có trong lớp chưa
                    if (!classEntity.Students.Any(s => s.StudentId == student.StudentId))
                    {
                        classEntity.Students.Add(student);
                    }
                }

                _context.SaveChanges();
                transaction.Commit();

                return null; // Success
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return $"Lỗi database khi thêm học viên: {ex.Message}";
            }
        }

        public string CreateClass(Class newClass)
        {
            try
            {
                _context.Classes.Add(newClass);
                _context.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteClass(int classId)
        {
            try
            {
                Class? classes = GetClassById(classId);
                if (classes != null)
                {
                    _context.Classes.Remove(classes);
                    _context.SaveChanges();
                }
                return null;
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Class> GetAllClasses()
        {
            return _context.Classes.ToList();
        }

        public List<Student> getAllStudentByClassId(int classId)
        {
            try{
                return _context.Classes
                                .Include(c => c.Students)
                                .Where(c => c.ClassId == classId)
                                .SelectMany(c => c.Students)
                                .ToList();
            }catch(Exception)
            {
                return new List<Student>();
            }
        }

        public Class? GetClassById(int classId)
        {
            try
            {
                return _context.Classes.FirstOrDefault(c => c.ClassId == classId);
            }
            catch (Exception)
            {
                return null;
            }
        }

      

        public string UpdateClass(Class updatedClass)
        {
            try
            {
                _context.Classes.Update(updatedClass);
                _context.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public int GetStudentCountInClass(int classId)
        {
            try
            {
                return _context.Classes
                    .Where(c => c.ClassId == classId)
                    .Select(c => c.Students.Count)
                    .FirstOrDefault();
            }
            catch
            {
                return 0;
            }
        }
        public List<int> GetExistingStudentIds(List<int> studentIds)
        {
            try
            {
                return _context.Students
                    .Where(s => studentIds.Contains(s.StudentId))
                    .Select(s => s.StudentId)
                    .ToList();
            }
            catch
            {
                return new List<int>();
            }
        }

        public List<int> GetStudentsAlreadyInClass(int classId, List<int> studentIds)
        {
            try
            {
                return _context.Classes
                    .Where(c => c.ClassId == classId)
                    .SelectMany(c => c.Students)
                    .Where(s => studentIds.Contains(s.StudentId))
                    .Select(s => s.StudentId)
                    .ToList();
            }
            catch
            {
                return new List<int>();
            }
        }

        public string RemoveStudentFromClass(int classId, int studentId)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                // Lấy class entity với Students navigation
                var classEntity = _context.Classes
                    .Include(c => c.Students)
                    .FirstOrDefault(c => c.ClassId == classId);

                if (classEntity == null)
                {
                    return "Lớp học không tồn tại.";
                }

                // Tìm học viên trong lớp
                var studentEntity = classEntity.Students
                    .FirstOrDefault(s => s.StudentId == studentId);

                if (studentEntity == null)
                {
                    return "Học viên không có trong lớp này.";
                }

                // Xóa học viên khỏi lớp (xóa relationship, không xóa student)
                classEntity.Students.Remove(studentEntity);

                _context.SaveChanges();
                transaction.Commit();

                return null; // Success
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return $"Lỗi database khi xóa học viên: {ex.Message}";
            }
        }

        public bool IsStudentInClass(int classId, int studentId)
        {
            try
            {
                return _context.Classes
                    .Where(c => c.ClassId == classId)
                    .SelectMany(c => c.Students)
                    .Any(s => s.StudentId == studentId);
            }
            catch
            {
                return false;
            }
        }

        public List<int> GetStudentsInClass(int classId, List<int> studentIds)
        {
            try
            {
                return _context.Classes
                    .Where(c => c.ClassId == classId)
                    .SelectMany(c => c.Students)
                    .Where(s => studentIds.Contains(s.StudentId))
                    .Select(s => s.StudentId)
                    .ToList();
            }
            catch
            {
                return new List<int>();
            }
        }

        public List<Class> GetExpiredClasses(DateOnly today)
        {
            try
            {
                return _context.Classes
                    .Include(c => c.Students)
                    .Where(c => c.Status == true && c.EndDate < today)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách lớp hết hạn: {ex.Message}");
            }
        }

        public List<Class> GetUpcomingClasses(DateOnly today)
        {
            try
            {
                return _context.Classes
                    .Where(c => c.Status == false && c.StartDate == today)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách lớp sắp bắt đầu: {ex.Message}");
            }
        }

        public void RemoveAllStudentsFromClass(int classId)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var classEntity = _context.Classes
                    .Include(c => c.Students)
                    .FirstOrDefault(c => c.ClassId == classId);

                if (classEntity != null && classEntity.Students.Any())
                {
                    // Xóa tất cả học viên khỏi lớp (chỉ xóa relationship)
                    classEntity.Students.Clear();
                    _context.SaveChanges();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Lỗi khi xóa học viên khỏi lớp: {ex.Message}");
            }
        }

        public List<Class> StudentInClassById(int studentId)
        {
            try
            {
                return _context.Classes
                    .Include(c => c.Students)
                    .Where(c => c.Students.Any(s => s.StudentId == studentId))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách lớp của học viên: {ex.Message}");
            }
        }
    }
}
