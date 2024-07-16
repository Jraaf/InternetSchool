using InternetSchool.Models;
using InternetShcool.DAL.Repository.Base;

namespace InternetShcool.DAL.Repository.Interfaces;

public interface ITeacherRepository : IRepo<Teacher,int>
{
    Task<List<Teacher>> GetAllTeachers();
    Task<Teacher> GetTeacherById(int id);
    Task<Teacher> GetTeacherByName(string groupName);
    Task<bool> PostTeacher(Teacher group);
    Task<bool> DeleteTeacherById(int id);
    Task<bool> DeleteTeacherByName(string group);
    Task<bool> UpdateTeacher(int id, Teacher group);
}
