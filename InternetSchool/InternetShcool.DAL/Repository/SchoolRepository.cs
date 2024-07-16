using InternetSchool.Models;
using InternetShcool.DAL.EF;
using InternetShcool.DAL.Repository.Base;
using InternetShcool.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShcool.DAL.Repository;

public class SchoolRepository : Repo<School, int>, ISchoolRepository
{
    private readonly InternetSchoolDBContext context;
    public SchoolRepository(InternetSchoolDBContext context)
        : base(context)
    {
        this.context = context;
    }


    public async Task<List<School>> GetSchoolByName(string schoolName)
    {
        try
        {
            var res = await (from s in context.Schools
                             where s.Name == schoolName
                             select s).ToListAsync();
            return res;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
