using InternetSchool.Models;
using InternetScool.Common.DTO;
using InternetScool.Common.DTO.Out;
using ServiceStack;

namespace InternetScool.BLL.Service.Interfaces
{
    public interface ITeacherService
    {
        public Task<List<TeacherDTO>> GetAll();
        public Task<TeacherDTO> GetById(int Id);
        public Task<List<TeacherDTO>> GetByName(string Name);
        public Task<TeacherDTO> Post(CreateTeacherDTO DTO);
        public Task<bool> Delete(int Id);
        public Task<TeacherDTO> Update(CreateTeacherDTO CreateDTO, int Id);
    }
}
