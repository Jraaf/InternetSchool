using InternetSchool.Models;
using InternetShcool.DAL.EF;
using InternetShcool.DAL.Repository.Base;
using InternetShcool.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShcool.DAL.Repository;

public class SubjectRepository : Repo<Subject, int>, ISubjectRepository
{
    private readonly InternetSchoolDBContext context;
    public SubjectRepository(InternetSchoolDBContext context)
        : base(context)
    {
        this.context = context;
    }

    public async Task<List<Subject>> GetByName(string name)
    {
        try
        {
            var res = await (from s in context.Subjects
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
