using InternetSchool.Models;
using InternetShcool.DAL.Repository.Base;

namespace InternetShcool.DAL.Repository.Interfaces;

public interface IGroupRepository : IRepo<Group, int>
{
    Task<List<Group>> GetAllGroups();
    Task<Group> GetGroupById(int id);
    Task<List<Group>> GetGroupByName(string groupName);
    Task<bool> PostGroup(Group group);
    Task<bool> DeleteGroupById(int id);
    Task<bool> DeleteGroupByName(string name);
    Task<bool> UpdateGroup(int id, Group group);
}
