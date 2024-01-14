using AutoMapper;
using InternetScool.BLL.DTO.Out;
using InternetScool.BLL.DTO;
using InternetShcool.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetSchool.Models;
using InternetScool.BLL.Service.Interfaces;

namespace InternetScool.BLL.Service
{
    public class StudentService : IStudentService
    {
        private readonly IMapper mapper;
        private readonly IStudentRepository repo;
        public StudentService(IStudentRepository repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<bool> DeleteStudentById(int StudentId)
        {
            if (StudentId > 0)
            {
                return await repo.DeleteStudentById(StudentId);
            }
            return false;
        }

        public async Task<StudentDTO> GetStudentById(int StudentId)
        {
            StudentDTO res=new();
            if(StudentId > 0)
            {
                var data = await repo.GetStudentById(StudentId);
                res = mapper.Map<StudentDTO>(data);
            }
            return res; 
        }
        public async Task<List<StudentDTO>> GetStudentByName(string Name)
        { 
            var data = await repo.GetStudentByName(Name);
            return mapper.Map<List<StudentDTO>>(data);
        }

        public async Task<List<StudentDTO>> GetAllStudents()
        {
            var data = await repo.GetAllStudents();
            return mapper.Map<List<StudentDTO>>(data);
        }

        public async Task<bool> PostStudent(CreateStudentDTO group)
        {
            var data = mapper.Map<Student>(group);
            return await repo.PostStudent(data);
        }

        public async Task<bool> UpdateStudent(int Id,CreateStudentDTO group)
        {
            var data = mapper.Map<Student>(group);
            return await repo.UpdateStudent(Id, data);
        }

        public Task<bool> DeleteStudentByName(string student)
        {
            throw new NotImplementedException();
        }
    }
}
