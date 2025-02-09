using InternetSchool.DAL.EF;
using InternetSchool.DAL.Repository.Base;
using InternetSchool.DAL.Repository.Interfaces;
using InternetSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetSchool.DAL.Repository;

public class SchoolRepository : Repo<School, int>, ISchoolRepository
{
    private readonly InternetSchoolDBContext context;
    public SchoolRepository(InternetSchoolDBContext context)
        : base(context)
    {
        this.context = context;
    }


    public async Task<List<School>> GetByName(string name)
    {
        try
        {
            var res = await (from s in context.Schools
                             where s.Name == name
                             select s).ToListAsync();
            return res;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
