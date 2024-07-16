using InternetSchool.Models;
using InternetShcool.DAL.Repository.Base;

namespace InternetShcool.DAL.Repository.Interfaces;

public interface IGroupRepository : IRepo<Group, int>
{
    Task<List<Group>> GetGroupByName(string groupName);
    Task<bool> DeleteGroupByName(string name);
}
