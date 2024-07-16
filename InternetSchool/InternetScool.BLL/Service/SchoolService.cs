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
    public class SchoolService : ISchoolService
    {
        private readonly IMapper mapper;
        private readonly IRepository<School> repo;
        public SchoolService(IRepository<School> repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<bool> Delete(int Id)
        {
            var group = repo.FirstOrDefault(s => s.Id == Id)
                ?? throw new NotFoundException(Id);
            return await repo.DeleteAsync(group);
        }

        public async Task<SchoolDTO> GetById(int Id)
        {
            var group = await repo.FirstAsync(s => s.Id == Id)
                ?? throw new NotFoundException(Id);
            var res = mapper.Map<SchoolDTO>(group);
            return res;
        }

        public async Task<List<SchoolDTO>> GetAll()
        {
            var data = await repo.GetAllAsync();
            return mapper.Map<List<SchoolDTO>>(data);
        }

        public async Task<bool> Post(CreateSchoolDTO group)
        {
            var data = mapper.Map<School>(group);
            return await repo.AddAsync(data);
        }

        public async Task<bool> Update(CreateSchoolDTO group, int Id)
        {
            var data = mapper.Map<School>(group);
            return await repo.UpdateAsync(data, Id);
        }
    }
}
