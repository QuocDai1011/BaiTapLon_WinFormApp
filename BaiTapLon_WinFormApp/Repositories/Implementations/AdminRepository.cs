using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Repositories.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly EnglishCenterDbContext _context;

        public AdminRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }
        public Admin? getAdminByEmail(string email)
        {
            try
            {
                return _context.Admins.FirstOrDefault(t => t.Email == email);
            }
            catch (Exception ex) {
                return null;
            }
        }

        public void updateAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }
    }
}
