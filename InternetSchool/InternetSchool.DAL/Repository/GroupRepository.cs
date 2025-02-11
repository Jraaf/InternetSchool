using InternetSchool.DAL.EF;
using InternetSchool.DAL.Repository.Base;
using InternetSchool.DAL.Repository.Interfaces;
using InternetSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetSchool.DAL.Repository;

public class GroupRepository : Repo<Group, int>, IGroupRepository
{
    private readonly InternetSchoolDBContext context;
    public GroupRepository(InternetSchoolDBContext context)
        : base(context)
    {
        this.context = context;
    }

    public async Task<List<Group>> GetByName(string name)
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
