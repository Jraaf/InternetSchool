using InternetSchool.Models;
using InternetShcool.DAL.Repository.Base;

namespace InternetShcool.DAL.Repository.Interfaces;

public interface ISchoolRepository : IRepo<School, int>
{
    Task<List<School>> GetByName(string name);
}
