using BaiTapLon_WinFormApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Services.Interfaces
{
    public interface ICourseService
    {
        Course GetCourseByIdClass(int classId);
    }
}
