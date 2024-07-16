using AutoMapper;
using InternetScool.BLL.Service.Interfaces;
using InternetSchool.Models;
using InternetShcool.DAL.Repository.Interfaces;
using InternetScool.Common.DTO.Out;
using InternetScool.Common.DTO;
using InternetSchool.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace InternetScool.BLL.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Teacher> repo;
        public TeacherService(IRepository<Teacher> repo, IMapper mapper)
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

        public async Task<TeacherDTO> GetById(int Id)
        {
            var group = await repo.FirstAsync(s => s.Id == Id)
                ?? throw new NotFoundException(Id);
            var res = mapper.Map<TeacherDTO>(group);
            return res;
        }

        public async Task<List<TeacherDTO>> GetAll()
        {
            var data = await repo.GetAllAsync();
            return mapper.Map<List<TeacherDTO>>(data);
        }

        public async Task<bool> Post(CreateTeacherDTO group)
        {
            var data = mapper.Map<Teacher>(group);
            return await repo.AddAsync(data);
        }

        public async Task<bool> Update(CreateTeacherDTO group, int Id)
        {
            var data = mapper.Map<Teacher>(group);
            return await repo.UpdateAsync(data, Id);
        }
    }
}
