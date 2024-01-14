
using InternetScool.BLL.DTO;
using InternetScool.BLL.DTO.Out;

namespace InternetScool.BLL.Service.Interfaces
{
    public interface IGroupService
    {
        Task<List<GroupDTO>> GetGroups();
        Task<GroupDTO> GetGroupById(int Id);
        Task<List<GroupDTO>> GetGroupByName(string Name);
        Task<bool> PostGroup(CreateGroupDTO group);
        Task<bool> DeleteGroup(int GroupId);
        Task<bool> UpdateGroup(CreateGroupDTO group, int Id);
    }
}
