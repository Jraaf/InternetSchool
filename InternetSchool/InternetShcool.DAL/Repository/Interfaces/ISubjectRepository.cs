using InternetSchool.Models;
using InternetShcool.DAL.Repository.Base;

namespace InternetShcool.DAL.Repository.Interfaces;

public interface ISubjectRepository: IRepo<Subject, int>
{
    Task<List<Subject>> GetSubjectByName(string groupName);
}
