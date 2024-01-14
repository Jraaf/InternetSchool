using InternetSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShcool.DAL.Repository.Interfaces
{
    public interface ISchoolRepository
    {
        Task<List<School>> GetAllSchools();
        Task<School> GetSchoolById(int id);
        Task<List<School>> GetSchoolByName(string groupName);
        Task<bool> PostSchool(School group);
        Task<bool> DeleteSchoolById(int id);
        Task<bool> DeleteSchoolByName(string group);
        Task<bool>UpdateSchool(int id, School group);
    }
}
