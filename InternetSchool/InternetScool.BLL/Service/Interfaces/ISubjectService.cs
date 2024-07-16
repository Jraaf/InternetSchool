using InternetSchool.Models;
using InternetScool.Common.DTO;
using InternetScool.Common.DTO.Out;
using ServiceStack;

namespace InternetScool.BLL.Service.Interfaces
{
    public interface ISubjectService
    {
        public Task<List<SubjectDTO>> GetAll();
        public Task<SubjectDTO> GetById(int Id);
        public Task<bool> Post(CreateSubjectDTO group);
        public Task<bool> Delete(int Id);
        public Task<bool> Update(CreateSubjectDTO CreateDTO, int Id);
    }
}
