
﻿using BaiTapLon_WinFormApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_WinFormApp.Services.Interfaces
{
    public interface IClassService
    {

        List<Class> GetAllClassesByIdTeacher(int teacherId);
        List<Class> getAllClass();
        string createClass(Class newClass);
        string updateClass(Class updatedClass);
        string deleteClass(int classId);

        Class? getClassById(int classId);

        List<Student> getAllStudentByClassId(int classId);
        
        string addStudentsToClass(int classId, List<int> studentIds);
        string removeStudentFromClass(int classId, int studentId);

        void UpdateExpiredClasses();

        void ActivateUpcomingClasses();

        void RunAutoUpdate();
        List<Class> StudentInClassByStudentId(int studentId);
        void RemoveStudentFromClasses(int studentId);
    }
}
