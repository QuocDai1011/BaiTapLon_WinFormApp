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
    }
}
