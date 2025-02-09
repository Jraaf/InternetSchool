using InternetSchool.DAL.EF;
using InternetSchool.DAL.Repository.Base;
using InternetSchool.DAL.Repository.Interfaces;
using InternetSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetSchool.DAL.Repository;

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
