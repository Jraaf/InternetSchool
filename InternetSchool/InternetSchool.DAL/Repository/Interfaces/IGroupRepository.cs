using InternetSchool.DAL.Repository.Base;
using InternetSchool.Models;

namespace InternetSchool.DAL.Repository.Interfaces;

public interface IGroupRepository : IRepo<Group, int>
{
    Task<List<Group>> GetByName(string name);
}
