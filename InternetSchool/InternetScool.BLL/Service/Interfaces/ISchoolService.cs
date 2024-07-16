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
        public Task<bool> Post(CreateSchoolDTO school);
        public Task<bool> Delete(int Id);
        public Task<bool> Update(CreateSchoolDTO CreateDTO, int Id);
    }
}
