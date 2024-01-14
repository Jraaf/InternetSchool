using AutoMapper;
using Azure.Core;
using InternetScool.BLL.Service.Interfaces;
using InternetSchool.Models;
using InternetScool.BLL.DTO.Out;
using InternetScool.BLL.DTO;
using InternetShcool.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetScool.BLL.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly IMapper mapper;
        private readonly ITeacherRepository repo;
        public TeacherService(ITeacherRepository repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<bool> DeleteTeacherById(int TeacherId)
        {
            return await repo.DeleteTeacherById(TeacherId);
        }

        public async Task<bool> DeleteTeacherByName(string Name)
        {
            return await repo.DeleteTeacherByName(Name);
        }

        public async Task<TeacherDTO> GetTeacherById(int TeacherId)
        {
            var data = await repo.GetTeacherById(TeacherId);
            return mapper.Map<TeacherDTO>(data);
        }

        public async Task<TeacherDTO> GetTeacherByName(string Name)
        {
            var data = await repo.GetTeacherByName(Name);
            return mapper.Map<TeacherDTO>(data);
        }

        public async Task<List<TeacherDTO>> GetTeachers()
        {
            var data = await repo.GetAllTeachers();
            return mapper.Map<List<TeacherDTO>>(data);
        }

        public async Task<bool> PostTeacher(CreateTeacherDTO group)
        {
            var data = mapper.Map<Teacher>(group);
            return await repo.PostTeacher(data);
        }

        public async Task<bool> UpdateTeacher(int Id, CreateTeacherDTO group)
        {
            var data = mapper.Map<Teacher>(group);
            return await repo.UpdateTeacher(Id, data);
        }
    }
}
