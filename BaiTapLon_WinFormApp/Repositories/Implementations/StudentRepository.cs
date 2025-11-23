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

        public string createStudent(Student student)
        {
            string errorMessage = "";
            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
            }
            catch(SqlException sqlEx)
            {
                // Handle SQL duplicate key errors with friendly messages
                if (sqlEx.Number ==2627 || sqlEx.Number ==2601)
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
                if (baseEx is SqlException innerSql && (innerSql.Number ==2627 || innerSql.Number ==2601))
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
            if(student != null)
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
    }
}
