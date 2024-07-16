using InternetSchool.Models;
using InternetShcool.DAL.Repository.Base;

namespace InternetShcool.DAL.Repository.Interfaces;

public interface IStudentRepository : IRepo<Student, int>
{
    Task<List<Student>> GetStudentByName(string name);
}
