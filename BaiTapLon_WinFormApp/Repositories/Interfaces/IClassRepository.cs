
using BaiTapLon_WinFormApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Repositories.Interfaces
{
    public interface IClassRepository
    {
        List<Class> GetAllClassesByIdTeacher(int teacherId);

        List<Class> GetAllClasses();

        string CreateClass(Class newClass);

        string UpdateClass(Class updatedClass);

        string DeleteClass(int classId);

        Class? GetClassById(int classId);

        List<Student> getAllStudentByClassId(int classId);
        string AddStudentsToClass(int classId, List<int> studentIds);

        int GetStudentCountInClass(int classId);

        List<int> GetExistingStudentIds(List<int> studentIds);

        List<int> GetStudentsAlreadyInClass(int classId, List<int> studentIds);

        string RemoveStudentFromClass(int classId, int studentId);

        bool IsStudentInClass(int classId, int studentId);

        List<int> GetStudentsInClass(int classId, List<int> studentIds);

        List<Class> GetExpiredClasses(DateOnly today);

        List<Class> GetUpcomingClasses(DateOnly today);

        void RemoveAllStudentsFromClass(int classId);

        List<Class> StudentInClassById(int studentId);
    }
}
