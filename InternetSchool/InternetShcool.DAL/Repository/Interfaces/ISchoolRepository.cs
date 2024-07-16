using InternetSchool.Models;
using InternetShcool.DAL.Repository.Base;

namespace InternetShcool.DAL.Repository.Interfaces;

public interface ISchoolRepository : IRepo<School, int>
{
    Task<List<School>> GetSchoolByName(string groupName);
    Task<bool> DeleteSchoolByName(string group);
}
