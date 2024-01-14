using InternetSchool.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShcool.DAL.Repository.Interfaces
{
    public interface IGroupRepository
    {
        Task<List<Group>> GetAllGroups();
        Task<Group> GetGroupById(int id);
        Task<List<Group>> GetGroupByName(string groupName);
        Task<bool> PostGroup(Group group);
        Task<bool> DeleteGroupById(int id);
        Task<bool> DeleteGroupByName(string name);
        Task<bool> UpdateGroup(int id,Group group);
    }
}
