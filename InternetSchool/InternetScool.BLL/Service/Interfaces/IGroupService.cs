
using InternetSchool.Models;
using InternetScool.Common.DTO;
using InternetScool.Common.DTO.Out;
using ServiceStack;

namespace InternetScool.BLL.Service.Interfaces
{
    public interface IGroupService:IService
    {
        public Task<List<GroupDTO>> GetAll();
        public Task<GroupDTO> GetById(int Id);
        public Task<List<GroupDTO>> GetByName(string Name);
        public Task<GroupDTO> Post(CreateGroupDTO DTO);
        public Task<bool> Delete(int Id);
        public Task<GroupDTO > Update(CreateGroupDTO CreateDTO, int Id);
    }
}
