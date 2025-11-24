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
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public Teacher? getTeacherByEmai(string email)
        {
            try
            {
               return _teacherRepository.getTeacherByEmail(email);

            }catch(Exception ex)
            {
                return null;
            }
        }

        public Teacher GetTeacherById(int id)
        {
            return _teacherRepository.GetTeacherById(id);
        }

        public int UpdateProfile(int id, Teacher teacherUpdated)
        {
            return _teacherRepository.UpdateProfile(id, teacherUpdated);
        }
    }
}
