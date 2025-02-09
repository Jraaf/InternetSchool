using InternetSchool.DAL.EF;
using InternetSchool.DAL.Repository.Base;
using InternetSchool.DAL.Repository.Interfaces;
using InternetSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetSchool.DAL.Repository;

public class TeacherRepository : Repo<Teacher, int>, ITeacherRepository
{
    private readonly InternetSchoolDBContext context;
    public TeacherRepository(InternetSchoolDBContext context)
        : base(context)
    {
        this.context = context;
    }
    public async Task<List<Teacher>> GetByName(string name)
    {
        try
        {
            var res = await (from s in context.Teachers
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
