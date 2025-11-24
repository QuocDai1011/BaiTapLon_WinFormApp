using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Services.Interfaces
{
    public interface IAuthService
    {
        bool Login(string email, string password, out string role);
        bool RegisterStudent(string firstName, string lastName, string email, string password, string address, DateTime dob, bool gender, string phone, string parentPhone);
        Task<bool> ChangePasswordAsync(string email, string newPassword, string confirm);
    }
}
