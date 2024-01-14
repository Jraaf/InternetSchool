

using InternetScool.BLL.DTO;
using InternetScool.BLL.DTO.Out;

namespace InternetScool.BLL.Service.Interfaces
{
    public interface ISchoolService
    {
        Task<List<SchoolDTO>> GetSchools();        
        Task<SchoolDTO> GetSchoolById(int ShcoolId);
        Task<List<SchoolDTO>>GetSchoolByName(string Name);
        Task<bool> PostSchool(CreateSchoolDTO school);
        Task<bool> DeleteSchool(int SchoolId);
        Task<bool> UpdateSchool(CreateSchoolDTO school, int Id);

    }
}
