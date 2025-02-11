using InternetSchool.DAL.EF;
using InternetSchool.DAL.Repository.Base;
using InternetSchool.DAL.Repository.Interfaces;
using InternetSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetSchool.DAL.Repository;

public class StudentRepository : Repo<Student, int>, IStudentRepository
{
    private readonly InternetSchoolDBContext context;
    public StudentRepository(InternetSchoolDBContext context)
        : base(context)
    {
        this.context = context;
    }

    public async Task<List<Student>> GetByName(string name)
    {
        try
        {
            var res = await (from d in context.Students
                             where d.Name == name
                             select d).ToListAsync();
            return res;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
