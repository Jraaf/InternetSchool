using InternetSchool.Models;
using InternetShcool.DAL.EF;
using InternetShcool.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShcool.DAL.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly InternetSchoolDBContext context;
        public GroupRepository(InternetSchoolDBContext context) 
        {
            this.context = context;
        }
        public async Task<bool> DeleteGroupById(int id)
        {
            try
            {
                var group=await context.Groups.FindAsync(id);
                if(group != null)
                {
                    context.Groups.Remove(group);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteGroupByName(string name)
        {
            try
            {
                var data = context.Groups.ToList();
                var group=(from d in data
                          where d.Name == name
                          select d).ToList().First();
                if (group != null)
                {   
                    context.Remove(group);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Group>> GetAllGroups()
        {
            try
            {
                var data=await context.Groups.ToListAsync();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Group> GetGroupById(int id)
        {
            try
            {
                var res = await context.Groups.FindAsync(id);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Group>> GetGroupByName(string groupName)
        {
            try
            {
                var data = await context.Groups.ToListAsync();
                var res = (from d in data
                           where d.Name == groupName
                           select d).ToList();
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> PostGroup(Group group)
        {
            try
            {
                await context.AddAsync(group);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateGroup(int groupId, Group group)
        {
            try
            {
                var data = await context.Groups.FindAsync(groupId);
                if (data != null)
                {
                    data.TeacherId = group.TeacherId;
                    data.SubjectId = group.SubjectId;
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
