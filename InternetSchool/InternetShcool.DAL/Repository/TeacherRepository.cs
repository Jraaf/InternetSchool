using InternetSchool.Models;
using InternetShcool.DAL.EF;
using InternetShcool.DAL.Repository.Base;
using InternetShcool.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShcool.DAL.Repository;

public class TeacherRepository : Repo<Teacher, int>, ITeacherRepository
{
    private readonly InternetSchoolDBContext context;
    public TeacherRepository(InternetSchoolDBContext context)
        : base(context)
    {
        this.context = context;
    }
    public async Task<List<Teacher>> GetTeacherByName(string teacherName)
    {
        try
        {
            var res = await (from s in context.Teachers
                             where s.Name == teacherName
                             select s).ToListAsync();
            return res;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
