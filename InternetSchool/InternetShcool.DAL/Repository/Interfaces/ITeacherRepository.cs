using InternetSchool.Models;
using InternetShcool.DAL.Repository.Base;

namespace InternetShcool.DAL.Repository.Interfaces;

public interface ITeacherRepository : IRepo<Teacher,int>
{
    Task<List<Teacher>> GetTeacherByName(string name);
}
