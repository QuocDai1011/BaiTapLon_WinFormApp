using BaiTapLon_WinFormApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Utils
{
    public class Validator
    {
        // 1. Validate số điện thoại Việt Nam (10 số, đầu 03/05/07/08/09)
        public static bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^(03|05|07|08|09)\d{8}$");
        }

        // 2. Validate CCCD (12 số)
        public static bool IsValidCCCD(string cccd)
        {
            return Regex.IsMatch(cccd, @"^\d{12}$");
        }

        // 3. Validate Email
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email,
                @"^[\w.-]+@([\w-]+\.)+[\w-]{2,}$",
                RegexOptions.IgnoreCase);
        }

        // 4. Validate Username (4–20 ký tự, chữ + số, không ký tự đặc biệt)
        public static bool IsValidUsername(string username)
        {
            return Regex.IsMatch(username, @"^[a-zA-Z0-9]{4,20}$");
        }

        // 5. Validate Password mạnh (ít nhất: 1 hoa + 1 thường + 1 số + 1 ký tự đặc biệt,
        //    tối thiểu 8 ký tự)
        public static bool IsStrongPassword(string password)
        {
            return Regex.IsMatch(password,
    @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':\""\\|,.<>\/?]).{8,}$");

        }

        // 6. Validate tuổi phải > 4
        public static bool IsValidAge(int age)
        {
            return age > 4;
        }

        public static List<string> ValidateStudent(Student student)
        {
            var errors = new List<string>();

            // 1. Username
            if (!Validator.IsValidUsername(student.UserName))
                errors.Add("Tên đăng nhập không hợp lệ (4–20 ký tự, chỉ chữ và số).");

            // 2. Email
            if (!Validator.IsValidEmail(student.Email))
                errors.Add("Email không hợp lệ.");

            // 3. Password
            if (!Validator.IsStrongPassword(student.Password))
                errors.Add("Mật khẩu không đủ mạnh. Phải có ít nhất 8 ký tự, gồm chữ hoa, chữ thường, số và ký tự đặc biệt.");

            // 4. Số điện thoại
            if (!Validator.IsValidPhone(student.PhoneNumber))
                errors.Add("Số điện thoại không hợp lệ.");

            // 5. Tuổi
            if (student.DateOfBirth != null)
            {
                int age = DateTime.Now.Year - student.DateOfBirth.Value.Year;
                if (!Validator.IsValidAge(age))
                    errors.Add("Tuổi của học sinh phải từ 4 tuổi trở lên.");
            }

            return errors;
        }
        public static List<string> ValidateClass(Class classObj)
        {
            var errors = new List<string>();

            // 1. Mã lớp
            if (string.IsNullOrWhiteSpace(classObj.ClassCode))
            {
                errors.Add("Mã lớp không được để trống.");
            }
            else if (classObj.ClassCode.Length > 20)
            {
                errors.Add("Mã lớp không được vượt quá 20 ký tự.");
            }
            else if (!Regex.IsMatch(classObj.ClassCode, @"^[A-Za-z0-9\-_]+$"))
            {
                errors.Add("Mã lớp chỉ được chứa chữ cái, số, dấu gạch ngang và gạch dưới.");
            }

            // 2. Tên lớp
            if (string.IsNullOrWhiteSpace(classObj.ClassName))
            {
                errors.Add("Tên lớp không được để trống.");
            }
            else if (classObj.ClassName.Length > 255)
            {
                errors.Add("Tên lớp không được vượt quá 255 ký tự.");
            }
            else if (classObj.ClassName.Length < 3)
            {
                errors.Add("Tên lớp phải có ít nhất 3 ký tự.");
            }

            // 3. Số học viên tối đa
            if (classObj.MaxStudent <= 0)
            {
                errors.Add("Số học viên tối đa phải lớn hơn 0.");
            }
            else if (classObj.MaxStudent > 100)
            {
                errors.Add("Số học viên tối đa không được vượt quá 100.");
            }
            else if (classObj.MaxStudent < 5)
            {
                errors.Add("Số học viên tối đa phải ít nhất 5 người để đảm bảo chất lượng lớp học.");
            }

            // 4. Số học viên hiện tại
            if (classObj.CurrentStudent < 0)
            {
                errors.Add("Số học viên hiện tại không được âm.");
            }
            else if (classObj.CurrentStudent > classObj.MaxStudent)
            {
                errors.Add($"Số học viên hiện tại ({classObj.CurrentStudent}) không được vượt quá số học viên tối đa ({classObj.MaxStudent}).");
            }

            // 5. Ngày bắt đầu và ngày kết thúc
            if (classObj.StartDate >= classObj.EndDate)
            {
                errors.Add("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.");
            }
            else
            {
                // Tính số tháng chênh lệch
                int monthsDifference = ((classObj.EndDate.Year - classObj.StartDate.Year) * 12)
                                     + classObj.EndDate.Month - classObj.StartDate.Month;

                if (monthsDifference < 4)
                {
                    errors.Add("Thời hạn học phải ít nhất 4 tháng.");
                }
                else if (monthsDifference > 24)
                {
                    errors.Add("Thời hạn học không được vượt quá 24 tháng (2 năm).");
                }
            }

            // 6. Ngày bắt đầu không được quá xa trong quá khứ
            if (classObj.StartDate < DateOnly.FromDateTime(DateTime.Now.AddMonths(-1)))
            {
                errors.Add("Ngày bắt đầu không được quá 1 tháng trong quá khứ.");
            }

            // 7. Ngày bắt đầu không được quá xa trong tương lai
            if (classObj.StartDate > DateOnly.FromDateTime(DateTime.Now.AddYears(2)))
            {
                errors.Add("Ngày bắt đầu không được quá 2 năm trong tương lai.");
            }

            // 8. Ca học
            if (classObj.Shift < 1 || classObj.Shift > 5)
            {
                errors.Add("Ca học phải từ 1 đến 5.");
            }

            // 9. Ghi chú (nếu có)
            if (!string.IsNullOrEmpty(classObj.Note) && classObj.Note.Length > 255)
            {
                errors.Add("Ghi chú không được vượt quá 255 ký tự.");
            }

            // 10. Link học online (nếu có)
            if (!string.IsNullOrEmpty(classObj.OnlineMeetingLink))
            {
                if (classObj.OnlineMeetingLink.Length > 500)
                {
                    errors.Add("Link học online không được vượt quá 500 ký tự.");
                }
                else if (!Uri.TryCreate(classObj.OnlineMeetingLink, UriKind.Absolute, out Uri? uriResult)
                         || (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
                {
                    errors.Add("Link học online không hợp lệ. Vui lòng nhập URL đầy đủ (bắt đầu bằng http:// hoặc https://).");
                }
            }

            // 11. Validate ngày tạo và ngày cập nhật
            if (classObj.CreateAt > DateOnly.FromDateTime(DateTime.Now))
            {
                errors.Add("Ngày tạo không được là ngày trong tương lai.");
            }

            if (classObj.UpdateAt < classObj.CreateAt)
            {
                errors.Add("Ngày cập nhật không được nhỏ hơn ngày tạo.");
            }

            // 12. Kiểm tra logic status
            if (!classObj.Status && classObj.CurrentStudent > 0)
            {
                errors.Add("Không thể đặt trạng thái không hoạt động khi lớp còn học viên.");
            }

            // 13. Kiểm tra lớp đã kết thúc
            if (classObj.EndDate < DateOnly.FromDateTime(DateTime.Now) && classObj.Status)
            {
                errors.Add("Lớp học đã kết thúc không thể ở trạng thái hoạt động.");
            }

            return errors;
        }

        // Hàm hỗ trợ: Validate khi cập nhật lớp học (cho phép linh hoạt hơn)
        public static List<string> ValidateClassForUpdate(Class classObj)
        {
            var errors = new List<string>();

            // Sử dụng lại các validation cơ bản
            errors.AddRange(ValidateClass(classObj));

            // Thêm validation đặc biệt cho update
            // Ví dụ: không cho phép giảm số học viên tối đa xuống dưới số học viên hiện tại
            if (classObj.MaxStudent < classObj.CurrentStudent)
            {
                errors.Add($"Không thể giảm số học viên tối đa xuống {classObj.MaxStudent} khi đang có {classObj.CurrentStudent} học viên.");
            }

            return errors;
        }

        // Hàm hỗ trợ: Validate khi thêm học viên vào lớp
        public static List<string> ValidateAddStudentToClass(Class classObj)
        {
            var errors = new List<string>();

            if (!classObj.Status)
            {
                errors.Add("Không thể thêm học viên vào lớp không hoạt động.");
            }

            if (classObj.CurrentStudent >= classObj.MaxStudent)
            {
                errors.Add($"Lớp học đã đầy ({classObj.CurrentStudent}/{classObj.MaxStudent} học viên).");
            }

            if (classObj.StartDate < DateOnly.FromDateTime(DateTime.Now))
            {
                errors.Add("Không thể thêm học viên vào lớp đã bắt đầu.");
            }

            if (classObj.EndDate < DateOnly.FromDateTime(DateTime.Now))
            {
                errors.Add("Không thể thêm học viên vào lớp đã kết thúc.");
            }

            return errors;
        }
    }
}
