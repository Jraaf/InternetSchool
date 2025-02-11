using InternetSchool.DAL.Repository.Base;
using InternetSchool.Models;

namespace InternetSchool.DAL.Repository.Interfaces;

public interface ISchoolRepository : IRepo<School, int>
{
    Task<List<School>> GetByName(string name);
}
