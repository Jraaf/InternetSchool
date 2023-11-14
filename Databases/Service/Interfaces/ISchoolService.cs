using Databases.Common.DTO;

namespace Databases.Service.Interfaces
{
    public interface ISchoolService
    {
        Task<List<SchoolDTO>> GetSchools();        
        Task<SchoolDTO> GetSchoolById(int ShcoolId);
        Task<bool> PostSchool(SchoolDTO school);
        Task<bool> DeleteSchool(int SchoolId);
        Task<bool> UpdateSchool(SchoolDTO school, int Id);
        Task<int> GetSchoolID(string SchoolName);
    }
}
