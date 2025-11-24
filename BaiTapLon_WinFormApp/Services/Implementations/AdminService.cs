using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Repositories.Interfaces;
using BaiTapLon_WinFormApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository )
        {
            _adminRepository = adminRepository; 
        }

        public Admin? getAdminByEmail(string email)
        {
            return _adminRepository.getAdminByEmail(email);
        }

        public void updateAdmin(Admin admin)
        {
            

        }
    }
}
