using InternetSchool.Models;
using InternetScool.Common.DTO;
using InternetScool.Common.DTO.Out;
using ServiceStack;

namespace InternetScool.BLL.Service.Interfaces
{
    public interface ISchoolService
    {
        public Task<List<SchoolDTO>> GetAll();
        public Task<SchoolDTO> GetById(int Id);
        public Task<SchoolDTO> Post(CreateSchoolDTO DTO);
        public Task<bool> Delete(int Id);
        public Task<SchoolDTO> Update(CreateSchoolDTO CreateDTO, int Id);
    }
}
