using AutoMapper;

using InternetScool.BLL.Service.Interfaces;

using InternetShcool.DAL.Repository.Interfaces;
using InternetSchool.Models;
using InternetScool.Common.DTO.Out;
using InternetScool.Common.DTO;

namespace InternetScool.BLL.Service
{
    public class SubjectService : ISubjectService
    {
        private readonly IMapper mapper;
        private readonly ISubjectRepository repo;
        public SubjectService(ISubjectRepository repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<bool> DeleteSubjectById(int SubjectId)
        {
            return await repo.DeleteSubjectById(SubjectId);
        }

        public async Task<bool> DeleteSubjectByName(string Name)
        {
           return await repo.DeleteSubjectByName(Name);
        }

        public async Task<SubjectDTO> GetSubjectById(int SubjectId)
        {
            var data = await repo.GetSubjectById(SubjectId);
            return mapper.Map<SubjectDTO>(data);
        }

        public async Task<SubjectDTO> GetSubjectByName(string Name)
        {
            var data = await repo.GetSubjectByName(Name);
            return mapper.Map<SubjectDTO>(data);
        }

        public async Task<List<SubjectDTO>> GetSubjects()
        {
            var data = await repo.GetAllSubjects();
            return mapper.Map<List<SubjectDTO>>(data);
        }

        public async Task<bool> PostSubject(CreateSubjectDTO group)
        {
            var data = mapper.Map<Subject>(group);
            return await repo.PostSubject(data);
        }

        public async Task<bool> UpdateSubject(int Id,CreateSubjectDTO group)
        {
            var data = mapper.Map<Subject>(group);
            return await repo.UpdateSubject(Id, data);
        }
    }
}
