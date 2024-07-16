using InternetSchool.Models;
using InternetShcool.DAL.Repository.Base;

namespace InternetShcool.DAL.Repository.Interfaces;

public interface IStudentRepository : IRepo<Student, int>
{
    Task<List<Student>> GetStudentByName(string groupName);
    Task<bool> PostStudent(Student group);
    Task<bool> DeleteStudentByName(string group);
}
