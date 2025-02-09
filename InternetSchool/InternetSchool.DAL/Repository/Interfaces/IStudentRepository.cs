using InternetSchool.DAL.Repository.Base;
using InternetSchool.Models;

namespace InternetSchool.DAL.Repository.Interfaces;

public interface IStudentRepository : IRepo<Student, int>
{
    Task<List<Student>> GetByName(string name);
}
