using InternetSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShcool.DAL.Repository.Interfaces
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllTeachers();
        Task<Teacher> GetTeacherById(int id);
        Task<Teacher> GetTeacherByName(string groupName);
        Task<bool> PostTeacher(Teacher group);
        Task<bool> DeleteTeacherById(int id);
        Task<bool> DeleteTeacherByName(string group);
        Task<bool> UpdateTeacher(int id, Teacher group);
    }
}
