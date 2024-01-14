using InternetSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShcool.DAL.Repository.Interfaces
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllSubjects();
        Task<Subject> GetSubjectById(int id);
        Task<Subject> GetSubjectByName(string groupName);
        Task<bool> PostSubject(Subject group);
        Task<bool> DeleteSubjectById(int id);
        Task<bool> DeleteSubjectByName(string group);
        Task<bool> UpdateSubject(int id, Subject group);
    }
}
