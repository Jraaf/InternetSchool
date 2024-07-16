using InternetSchool.Models;
using InternetShcool.DAL.Repository.Base;

namespace InternetShcool.DAL.Repository.Interfaces;

public interface ISubjectRepository: IRepo<Subject, int>
{
    Task<Subject> GetSubjectByName(string groupName);
    Task<bool> DeleteSubjectByName(string group);
}
