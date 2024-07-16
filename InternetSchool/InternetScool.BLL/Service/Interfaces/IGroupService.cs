
using InternetSchool.Models;
using InternetScool.Common.DTO;
using InternetScool.Common.DTO.Out;
using ServiceStack;

namespace InternetScool.BLL.Service.Interfaces
{
    public interface IGroupService:IService
    {
        public Task<List<Group>> GetAll();
        public Task<GroupDTO> GetById(int Id);
        public Task<bool> Post(Group group);
        public Task<bool> Delete(int Id);
        public Task<bool> Update(CreateGroupDTO CreateDTO, int Id);
    }
}
