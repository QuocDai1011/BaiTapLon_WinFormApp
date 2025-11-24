using BaiTapLon_WinFormApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Repositories.Interfaces
{
    public interface IAdminRepository
    {

        Admin? getAdminByEmail(string email);

        void updateAdmin(Admin admin);

    }
}
