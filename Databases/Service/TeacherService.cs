using AutoMapper;
using Azure.Core;
using Databases.DTO;
using Databases.DTO.Out;
using Databases.Models;
using Databases.Service.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Databases.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly InternetSchoolDBContext context;
        private readonly IMapper mapper;
        public TeacherService(InternetSchoolDBContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<bool> DeleteTeacher(int TeahcerId)
        {
            var teacher=await context.Teachers.FindAsync(TeahcerId);
            if(teacher == null)
            {
                return false;
            }
            else
            {
                context.Teachers.Remove(teacher);
                return true;
            }
        }

        public async Task<TeacherOutDTO> GetTeacherById(int Id)
        {
            TeacherOutDTO teacher=new();
            var res=await context.Teachers.FindAsync(Id);
            if (res != null)
            {
                teacher = mapper.Map<Teacher, TeacherOutDTO>(res);
            }
            return teacher;
        }

        public async Task<List<TeacherOutDTO>> GetTeachers()
        {
            var data=await context.Teachers.ToListAsync();
            var res=mapper.Map<List<Teacher>, List<TeacherOutDTO>>(data);
            return res;
        }
        public async Task<List<TeacherDTO>> GetTeachersOfSchool(int schoolId)
        {
            var data = await context.Teachers.ToListAsync();
            var teachers = (from t in data
                            where t.SchoolId == schoolId
                            select t)
                          .ToList();
            var res = mapper.Map<List<Teacher>, List<TeacherDTO>>(teachers);
            return res;
        }       

        public async Task<bool> PostTeacher(TeacherDTO teacher)
        {
            try
            {
                var data = mapper.Map<TeacherDTO, Teacher>(teacher);
                await context.Teachers.AddAsync(data);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RemoveTeahcerFromSchool(int teacherId)
        {
            try
            {
                var t = await context.Teachers.FindAsync(teacherId);
                if (t != null)
                {
                    t.SchoolId = 0;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> SetTeacherToSchool(int teacherId, int SchoolId)
        {
            try
            {
                var t = await context.Teachers.FindAsync(teacherId);
                if (t != null)
                {
                    t.SchoolId = SchoolId;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> UpdateTeacher(TeacherDTO teacher, int Id)
        {
            try
            {
                var data = mapper.Map<TeacherDTO, Teacher>(teacher);
                var t = await context.Teachers.FindAsync(Id);
                t.Name = data.Name;
                t.School = data.School;
                t.SchoolId = data.SchoolId;
                t.Description = data.Description;
                return true;
            }
            catch (Exception) 
            {
                return false;
                throw;
            }
        }
    }
}
