using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Repositories.Implementations
{
    public class ClassRepository : IClassRepository
    {
        private readonly EnglishCenterDbContext _context;

        public ClassRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }
        public List<Class> GetAllClasses()
        {
            return _context.Classes.ToList();
        }
    }
}
