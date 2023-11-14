using Databases.DTO;
using System.Text.RegularExpressions;

namespace Databases.Service.Interfaces
{
    public interface IGroupService
    {
        Task<List<GroupDTO>> GetGroups();
        Task<GroupDTO> GetGroupById(int Id);
        Task<bool> PostGroup(Group group);
        Task<bool> DeleteGroup(int GroupId);
        Task<bool> UpdateGroup(GroupDTO group, int Id);
    }
}
