using InternetSchool.Models;
using InternetShcool.DAL.Repository.Base;

namespace InternetShcool.DAL.Repository.Interfaces;

public interface ISchoolRepository : IRepo<School, int>
{
    Task<List<School>> GetAllSchools();
    Task<School> GetSchoolById(int id);
    Task<List<School>> GetSchoolByName(string groupName);
    Task<bool> PostSchool(School group);
    Task<bool> DeleteSchoolById(int id);
    Task<bool> DeleteSchoolByName(string group);
    Task<bool>UpdateSchool(int id, School group);
}
