using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Repositories.Interfaces;
using BaiTapLon_WinFormApp.Services.Interfaces;
using BaiTapLon_WinFormApp.Utils;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BaiTapLon_WinFormApp.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public bool Login(string email, string password, out string role)
        {
            role = null;

            string hash = _authRepository.GetPasswordHashByEmail(email, out role);
            if (hash == null)
            {
                return false;
            }

            if (BCrypt.Net.BCrypt.Verify(password, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RegisterStudent(string firstName, string lastName, string email, string password,
                                string address, DateTime dob, bool gender, string phone, string parentPhone)
        {
            if (_authRepository.EmailExists(email))
            {
                MessageBox.Show("Email đã tồn tại trong hệ thống!");
                return false;
            }

            string fullName = firstName + " " + lastName;

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            Student student = new Student
            {
                FullName = fullName,
                UserName = email,
                Email = email,
                Password = hashedPassword,
                Address = address ?? "",
                DateOfBirth = DateOnly.FromDateTime(dob),
                Gender = gender,
                PhoneNumber = phone ?? "",
                PhoneNumberOfParents = parentPhone ?? "",
                IsActive = true
            };

            _authRepository.AddStudent(student);
            return true;
        }
        public async Task<bool> ChangePasswordAsync(string email, string newPassword, string confirm)
        {
            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu mới!");
                return false;
            }

            if (newPassword != confirm)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!");
                return false;
            }

            if (string.IsNullOrEmpty(OtpStorage.CurrentEmail))
            {
                MessageBox.Show("Không tìm thấy email đang xác thực.");
                return false;
            }
            if(Validator.IsStrongPassword(newPassword) == false)
            {
                MessageBox.Show("Mật khẩu mới không đủ mạnh! Vui lòng đảm bảo mật khẩu có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt.");
                return false;
            }
            string hashed = BCrypt.Net.BCrypt.HashPassword(newPassword);
            var student = await _authRepository.GetStudentByEmailAsync(email);
            if (student != null)
            {
                student.Password = hashed;
                await _authRepository.UpdateStudentAsync(student);
                MessageBox.Show("Đổi mật khẩu Student thành công!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy Student.");
                return false;
            }
            OtpStorage.Clear();
            return true;
        }
    }
}
