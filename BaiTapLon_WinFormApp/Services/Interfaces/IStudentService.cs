using BaiTapLon_WinFormApp.Models;


namespace BaiTapLon_WinFormApp.Services.Interfaces
{
    public interface IStudentService
    {
        List<Class> GetRegisteredCourses(int studentId);

        List<Course> GetAvailableCourses(int studentId);
        bool UpdateStudent(int studentId, Student student);
        bool BuyCourse(int studentId, Course course, string payMethod);
        List<Student> getAllStudent();
        string createStudent(Student student);

        string updateStudent(Student student);

        string deleteStudent(int studentId);

        Student? GetStudentById(int studentId);
        Student? getStudentByEmail(string email);

    }
}