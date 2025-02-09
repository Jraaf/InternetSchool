using InternetSchool.DAL.Repository.Base;
using InternetSchool.Models;

namespace InternetSchool.DAL.Repository.Interfaces;

public interface ITeacherRepository : IRepo<Teacher,int>
{
    Task<List<Teacher>> GetByName(string name);
}
