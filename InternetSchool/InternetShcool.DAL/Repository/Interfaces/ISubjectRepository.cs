using InternetSchool.Models;
using InternetShcool.DAL.Repository.Base;

namespace InternetShcool.DAL.Repository.Interfaces;

public interface ISubjectRepository: IRepo<Subject, int>
{
    Task<List<Subject>> GetAllSubjects();
    Task<Subject> GetSubjectById(int id);
    Task<Subject> GetSubjectByName(string groupName);
    Task<bool> PostSubject(Subject group);
    Task<bool> DeleteSubjectById(int id);
    Task<bool> DeleteSubjectByName(string group);
    Task<bool> UpdateSubject(int id, Subject group);
}
