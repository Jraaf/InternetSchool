using InternetSchool.DAL.Repository.Base;
using InternetSchool.Models;

namespace InternetSchool.DAL.Repository.Interfaces;

public interface ISubjectRepository: IRepo<Subject, int>
{
    Task<List<Subject>> GetByName(string name);
}
