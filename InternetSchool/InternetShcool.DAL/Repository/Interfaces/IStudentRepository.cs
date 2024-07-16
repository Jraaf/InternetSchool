using InternetSchool.Models;
using InternetShcool.DAL.Repository.Base;

namespace InternetShcool.DAL.Repository.Interfaces;

public interface IStudentRepository : IRepo<Student, int>
{
    Task<List<Student>> GetAllStudents();
    Task<Student> GetStudentById(int id);
    Task<List<Student>> GetStudentByName(string groupName);
    Task<bool> PostStudent(Student group);
    Task<bool> DeleteStudentById(int id);
    Task<bool> DeleteStudentByName(string group);
    Task<bool> UpdateStudent(int id, Student group);
}
