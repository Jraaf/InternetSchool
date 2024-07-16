using InternetSchool.Models;
using InternetShcool.DAL.EF;
using InternetShcool.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using InternetShcool.DAL.Repository.Base;

namespace InternetShcool.DAL.Repository;

public class GroupRepository : Repo<Group, int>, IGroupRepository
{
    private readonly InternetSchoolDBContext context;
    public GroupRepository(InternetSchoolDBContext context)
        : base(context)
    {
        this.context = context;
    }

    public async Task<List<Group>> GetGroupByName(string name)
    {
        try
        {
            var data = await (from g in context.Groups
                              where g.Name == name
                              select g).ToListAsync();
            return data;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
