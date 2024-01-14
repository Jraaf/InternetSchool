using InternetSchool.Models;
using InternetShcool.DAL.EF;
using InternetShcool.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShcool.DAL.Repository
{
    public class TeacherRepository:ITeacherRepository
    {
        private readonly InternetSchoolDBContext context;
        public TeacherRepository(InternetSchoolDBContext context)
        {
            this.context = context;
        }
        public async Task<bool> DeleteTeacherById(int id)
        {
            try
            {
                var teacher = await context.Teachers.FindAsync(id);
                if (teacher != null)
                {
                    context.Teachers.Remove(teacher);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteTeacherByName(string name)
        {
            try
            {
                var data = context.Teachers.ToList();
                var teacher = (from d in data
                             where d.Name == name
                             select d).ToList().First();
                if (teacher != null)
                {
                    context.Remove(teacher);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Teacher>> GetAllTeachers()
        {
            try
            {
                var data = context.Teachers.ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Teacher> GetTeacherById(int id)
        {
            try
            {
                var data = context.Teachers.ToList();
                var res = (from d in data
                           where d.Id == id
                           select d).ToList().First();
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Teacher> GetTeacherByName(string teacherName)
        {
            try
            {
                var data = context.Teachers.ToList();
                var res = (from d in data
                           where d.Name == teacherName
                           select d).ToList().First();
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> PostTeacher(Teacher teacher)
        {
            try
            {
                await context.AddAsync(teacher);
                context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateTeacher(int teacherId, Teacher teacher)
        {
            try
            {
                var data = await context.Teachers.FindAsync(teacherId);
                if (data != null)
                {
                    data.SchoolId = teacher.SchoolId;
                    data.Name = teacher.Name;
                    data.Description = teacher.Description;
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
