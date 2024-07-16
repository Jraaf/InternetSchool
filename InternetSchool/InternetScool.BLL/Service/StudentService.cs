using AutoMapper;
using InternetShcool.DAL.Repository.Interfaces;
using InternetSchool.Models;
using InternetScool.BLL.Service.Interfaces;
using InternetScool.Common.DTO.Out;
using InternetScool.Common.DTO;
using InternetSchool.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace InternetScool.BLL.Service
{
    public class StudentService : IStudentService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Student> repo;
        public StudentService(IRepository<Student> repo, IMapper mapper)
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

        public async Task<StudentDTO> GetById(int Id)
        {
            var group = await repo.FirstAsync(s => s.Id == Id)
                ?? throw new NotFoundException(Id);
            var res = mapper.Map<StudentDTO>(group);
            return res;
        }

        public async Task<List<StudentDTO>> GetAll()
        {
            var data = await repo.GetAllAsync();
            return mapper.Map<List<StudentDTO>>(data);
        }

        public async Task<bool> Post(CreateStudentDTO group)
        {
            var data = mapper.Map<Student>(group);
            return await repo.AddAsync(data);
        }

        public async Task<bool> Update(CreateStudentDTO group, int Id)
        {
            var data = mapper.Map<Student>(group);
            return await repo.UpdateAsync(data, Id);
        }
    }
}
