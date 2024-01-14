using InternetScool.BLL.DTO;
using InternetScool.BLL.DTO.Out;

namespace InternetScool.BLL.Service.Interfaces
{
    public interface ISubjectService
    {
        Task<List<SubjectDTO>> GetSubjects();
        Task<SubjectDTO> GetSubjectByName(string Name);
        Task<SubjectDTO> GetSubjectById(int Id);
        Task<bool> PostSubject(CreateSubjectDTO subject);
        Task<bool> DeleteSubjectById(int Id);
        Task<bool> DeleteSubjectByName(string Name);
        Task<bool> UpdateSubject(int Id, CreateSubjectDTO newSubject);
    }
}
