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
        public Task<List<SubjectDTO>> GetByName(string Name);
        public Task<SubjectDTO> Post(CreateSubjectDTO DTO);
        public Task<bool> Delete(int Id);
        public Task<SubjectDTO> Update(CreateSubjectDTO CreateDTO, int Id);
    }
}
