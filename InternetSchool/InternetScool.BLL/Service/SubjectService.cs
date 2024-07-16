using AutoMapper;

using InternetScool.BLL.Service.Interfaces;

using InternetShcool.DAL.Repository.Interfaces;
using InternetSchool.Models;
using InternetScool.Common.DTO.Out;
using InternetScool.Common.DTO;
using InternetSchool.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace InternetScool.BLL.Service
{
    public class SubjectService : ISubjectService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Subject> repo;
        public SubjectService(IRepository<Subject> repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<bool> Delete(int Id)
        {
            var group = repo.FirstOrDefault(s => s.Id == Id)
                ?? throw new Exception("There is no such group");
            return await repo.DeleteAsync(group);
        }

        public async Task<SubjectDTO> GetById(int Id)
        {
            var group = await repo.FirstAsync(s => s.Id == Id)
                ?? throw new NotFoundException(Id);
            var res = mapper.Map<SubjectDTO>(group);
            return res;
        }

        public async Task<List<SubjectDTO>> GetAll()
        {
            var data = await repo.GetAllAsync();
            return mapper.Map<List<SubjectDTO>>(data);
        }

        public async Task<bool> Post(CreateSubjectDTO group)
        {
            var data = mapper.Map<Subject>(group);
            return await repo.AddAsync(data);
        }

        public async Task<bool> Update(CreateSubjectDTO group, int Id)
        {
            var data = mapper.Map<Subject>(group);
            return await repo.UpdateAsync(data, Id);
        }
    }
}
