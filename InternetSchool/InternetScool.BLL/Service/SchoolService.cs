using AutoMapper;
using InternetScool.BLL.Service.Interfaces;
using InternetScool.BLL.DTO.Out;
using InternetScool.BLL.DTO;
using InternetShcool.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using InternetSchool.Models;

namespace InternetScool.BLL.Service
{
    public class SchoolService : ISchoolService
    {
        private readonly IMapper mapper;
        private readonly ISchoolRepository repo;
        public SchoolService(ISchoolRepository repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<bool> DeleteSchool(int SchoolId)
        {
            return await repo.DeleteSchoolById(SchoolId);
        }

        public async Task<SchoolDTO> GetSchoolById(int SchoolId)
        {
            var data = await repo.GetSchoolById(SchoolId);
            return mapper.Map<SchoolDTO>(data);
        }

        public async Task<List<SchoolDTO>> GetSchoolByName(string Name)
        {
            var data=await repo.GetSchoolByName(Name);
            return mapper.Map<List<SchoolDTO>>(data);
        }

        public async Task<List<SchoolDTO>> GetSchools()
        {
            var data = await repo.GetAllSchools();
            return mapper.Map<List<SchoolDTO>>(data);
        }

        public async Task<bool> PostSchool(CreateSchoolDTO group)
        {
            var data = mapper.Map<School>(group);
            return await repo.PostSchool(data);
        }

        public async Task<bool> UpdateSchool(DTO.CreateSchoolDTO group, int Id)
        {
            var data = mapper.Map<School>(group);
            return await repo.UpdateSchool(Id, data);
        }
    }
}
