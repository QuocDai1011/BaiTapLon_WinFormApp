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
            }catch(SqlException sqlEx)
            {
                errorMessage = sqlEx.Message;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
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
                    errorMessage = sqlEx.Message;
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
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
                errorMessage = sqlEx.Message;
                return new List<Student>();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
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
                errorMessage = sqlEx.Message;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return errorMessage;

        }
    }
}
