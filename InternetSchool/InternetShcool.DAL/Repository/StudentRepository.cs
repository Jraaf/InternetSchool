using InternetSchool.Models;
using InternetShcool.DAL.EF;
using InternetShcool.DAL.Repository.Base;
using InternetShcool.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShcool.DAL.Repository;

public class StudentRepository : Repo<Student, int>, IStudentRepository
{
    private readonly InternetSchoolDBContext context;
    public StudentRepository(InternetSchoolDBContext context)
        : base(context)
    {
        this.context = context;
    }

    public async Task<List<Student>> GetStudentByName(string name)
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
