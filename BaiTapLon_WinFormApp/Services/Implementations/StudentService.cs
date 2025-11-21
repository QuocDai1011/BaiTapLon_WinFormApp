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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public string create()
        {
            string error = _studentRepository.create();
            return error;
        }

        public List<Student> getAll()
        {
            return _studentRepository.getAll();
        }
    }
}
