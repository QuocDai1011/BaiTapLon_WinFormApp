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
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public List<Class> GetAllClassesByIdTeacher(int teacherId)
        {
            var classes = _classRepository.GetAllClassesByIdTeacher(teacherId);
            var today = DateOnly.FromDateTime(DateTime.Now);
            foreach (var clazz in classes)
            {
                if (clazz.EndDate < today)
                {
                    clazz.Status = false;
                }
                else
                {
                    clazz.Status = true;
                }
            }
            return classes;
        }

        public string addStudentsToClass(int classId, List<int> studentIds)
        {
            try
            {
                // Validate input
                if (classId <= 0)
                {
                    return "Class ID không hợp lệ.";
                }

                if (studentIds == null || studentIds.Count == 0)
                {
                    return "Danh sách học viên không được để trống.";
                }

                if (studentIds.Any(id => id <= 0))
                {
                    return "Có Student ID không hợp lệ trong danh sách.";
                }

                // Kiểm tra lớp học có tồn tại không
                var classEntity = _classRepository.GetClassById(classId);
                if (classEntity == null)
                {
                    return "Lớp học không tồn tại.";
                }

                // Kiểm tra trạng thái lớp
                if (!classEntity.Status)
                {
                    return "Không thể thêm học viên vào lớp không hoạt động.";
                }

                // Kiểm tra số chỗ trống
                int currentStudentCount = _classRepository.GetStudentCountInClass(classId);
                int availableSlots = classEntity.MaxStudent - currentStudentCount;

                if (studentIds.Count > availableSlots)
                {
                    return $"Lớp chỉ còn {availableSlots} chỗ trống. Bạn đang cố thêm {studentIds.Count} học viên.";
                }

                // Kiểm tra học viên có tồn tại không
                var existingStudentIds = _classRepository.GetExistingStudentIds(studentIds);
                var invalidIds = studentIds.Except(existingStudentIds).ToList();

                if (invalidIds.Any())
                {
                    return $"Các học viên sau không tồn tại: {string.Join(", ", invalidIds)}";
                }

                // Kiểm tra học viên đã có trong lớp chưa
                var studentsAlreadyInClass = _classRepository.GetStudentsAlreadyInClass(classId, studentIds);
                if (studentsAlreadyInClass.Any())
                {
                    return $"Các học viên sau đã có trong lớp: {string.Join(", ", studentsAlreadyInClass)}";
                }

                // Thêm học viên vào lớp
                string errorMessage = _classRepository.AddStudentsToClass(classId, studentIds);

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return errorMessage;
                }

                // Cập nhật CurrentStudent
                classEntity.CurrentStudent = currentStudentCount + studentIds.Count;
                classEntity.UpdateAt = DateOnly.FromDateTime(DateTime.Now);
                _classRepository.UpdateClass(classEntity);

                return null; // Success
            }
            catch (Exception ex)
            {
                return $"Lỗi khi thêm học viên vào lớp: {ex.Message}";
            }
        }

        public string createClass(Class newClass)
        {
            try
            {
                // Validate class
                var errorMessages = Validator.ValidateClass(newClass);

                if (errorMessages.Count >= 1)
                {
                    // Sử dụng StringBuilder để gộp các lỗi
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Có lỗi khi tạo lớp học:");
                    sb.AppendLine(); // Dòng trống

                    foreach (var error in errorMessages)
                    {
                        sb.AppendLine(error);
                    }

                    return sb.ToString();
                }

                // Nếu không có lỗi, tạo lớp học
                _classRepository.CreateClass(newClass);
                return null; // Hoặc return string.Empty nếu muốn
            }
            catch (Exception ex)
            {
                return $"Lỗi khi tạo lớp học: {ex.Message}";
            }
        }


        public string deleteClass(int classId)
        {
            try
            {
                if (classId <= 0)
                {
                    return "Class ID không hợp lệ.";
                }
                return getClassById(classId) == null ? "Lớp học không tồn tại." : _classRepository.DeleteClass(classId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Class> getAllClass()
        {
            return _classRepository.GetAllClasses();
        }

        public List<Student> getAllStudentByClassId(int classId)
        {

            try
            {
                if (classId <= 0)
                {
                    return new List<Student>();
                }
                return _classRepository.getAllStudentByClassId(classId);
            }
            catch (Exception)
            {
                return new List<Student>();
            }

        }

        // riêng getById trả về Class nên khi không tìm thấy sẽ trả về null
        public Class? getClassById(int classId)
        {
            try
            {
                if (classId <= 0)
                {
                    return null;
                }
                return _classRepository.GetClassById(classId);
            }
            catch (Exception)
            {
                return null;
            }
        }


        public string updateClass(Class updatedClass)
        {
            try
            {
                // Validate class
                var errorMessages = Validator.ValidateClass(updatedClass);

                if (errorMessages.Count >= 1)
                {
                    // Sử dụng StringBuilder để gộp các lỗi
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Có lỗi khi cập nhật lớp học:");
                    sb.AppendLine(); // Dòng trống

                    foreach (var error in errorMessages)
                    {
                        sb.AppendLine(error);
                    }

                    return sb.ToString();
                }

                // Nếu không có lỗi, tạo lớp học
                _classRepository.UpdateClass(updatedClass);
                return null; // Hoặc return string.Empty nếu muốn
            }
            catch (Exception ex)
            {
                return $"Lỗi khi cập nhật lớp học: {ex.Message}";
            }
        }

        public string removeStudentFromClass(int classId, int studentId)
        {
            try
            {
                // Validate input
                if (classId <= 0)
                {
                    return "Class ID không hợp lệ.";
                }

                if (studentId <= 0)
                {
                    return "Student ID không hợp lệ.";
                }

                // Kiểm tra lớp học có tồn tại không
                var classEntity = _classRepository.GetClassById(classId);
                if (classEntity == null)
                {
                    return "Lớp học không tồn tại.";
                }

                // Kiểm tra học viên có trong lớp không
                bool isStudentInClass = _classRepository.IsStudentInClass(classId, studentId);
                if (!isStudentInClass)
                {
                    return "Học viên không có trong lớp này.";
                }



                // Xóa học viên khỏi lớp
                string errorMessage = _classRepository.RemoveStudentFromClass(classId, studentId);

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return errorMessage;
                }

                // Cập nhật CurrentStudent
                if (classEntity.CurrentStudent > 0)
                {
                    classEntity.CurrentStudent -= 1;
                    classEntity.UpdateAt = DateOnly.FromDateTime(DateTime.Now);
                    _classRepository.UpdateClass(classEntity);
                }

                return null; // Success
            }
            catch (Exception ex)
            {
                return $"Lỗi khi xóa học viên khỏi lớp: {ex.Message}";
            }
        }

        /// <summary>
        /// Tự động cập nhật trạng thái các lớp học đã kết thúc
        /// Gọi method này khi khởi động ứng dụng
        /// </summary>
        public void UpdateExpiredClasses()
        {
            try
            {
                var today = DateOnly.FromDateTime(DateTime.Now);

                // Lấy tất cả lớp học đang hoạt động và đã hết hạn
                var expiredClasses = _classRepository.GetExpiredClasses(today);

                if (expiredClasses == null || expiredClasses.Count == 0)
                {
                    return; // Không có lớp nào hết hạn
                }

                int updatedCount = 0;

                foreach (var classObj in expiredClasses)
                {
                    // Cập nhật trạng thái
                    classObj.Status = false;
                    classObj.CurrentStudent = 0;
                    classObj.UpdateAt = today;

                    // Xóa tất cả học viên khỏi lớp
                    _classRepository.RemoveAllStudentsFromClass(classObj.ClassId);

                    // Cập nhật class
                    _classRepository.UpdateClass(classObj);

                    updatedCount++;
                }

                // Log hoặc thông báo (tùy chọn)
                LogUpdate($"Đã tự động cập nhật {updatedCount} lớp học hết hạn.");
            }
            catch (Exception ex)
            {
                LogError($"Lỗi khi tự động cập nhật lớp học: {ex.Message}");
            }
        }

        /// <summary>
        /// Tự động kích hoạt các lớp học sắp bắt đầu (tùy chọn)
        /// </summary>
        public void ActivateUpcomingClasses()
        {
            try
            {
                var today = DateOnly.FromDateTime(DateTime.Now);

                // Lấy các lớp có ngày bắt đầu là hôm nay và chưa active
                var upcomingClasses = _classRepository.GetUpcomingClasses(today);

                if (upcomingClasses == null || upcomingClasses.Count == 0)
                {
                    return;
                }

                foreach (var classObj in upcomingClasses)
                {
                    classObj.Status = true;
                    classObj.UpdateAt = today;
                    _classRepository.UpdateClass(classObj);
                }

                LogUpdate($"Đã tự động kích hoạt {upcomingClasses.Count} lớp học bắt đầu hôm nay.");
            }
            catch (Exception ex)
            {
                LogError($"Lỗi khi kích hoạt lớp học: {ex.Message}");
            }
        }
        public void RunAutoUpdate()
        {
            Console.WriteLine("Đang khởi chạy chương trình cập nhật class tự động!");
            UpdateExpiredClasses();
            ActivateUpcomingClasses(); // Tùy chọn
        }

        private void LogUpdate(string message)
        {
            // Log vào file hoặc console
            Console.WriteLine($"[{DateTime.Now}] {message}");
            // Hoặc: File.AppendAllText("logs.txt", $"{DateTime.Now}: {message}\n");
        }

        private void LogError(string message)
        {
            Console.WriteLine($"[ERROR {DateTime.Now}] {message}");
            // Hoặc: File.AppendAllText("errors.txt", $"{DateTime.Now}: {message}\n");
        }

        public List<Class> StudentInClassByStudentId(int studentId)
        {
            if (studentId <= 0)
            {
                return new List<Class>();
            }

            return _classRepository.StudentInClassById(studentId);
        }

        public void RemoveStudentFromClasses(int studentId)
        {
            var classes = StudentInClassByStudentId(studentId);

            foreach (var classEntity in classes)
            {
                classEntity.CurrentStudent = Math.Max(0, classEntity.CurrentStudent - 1);
                classEntity.UpdateAt = DateOnly.FromDateTime(DateTime.Now);
                _classRepository.UpdateClass(classEntity);
            }
        }
    }
}
