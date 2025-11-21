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
    }
}
