using InternetSchool.Models;
using InternetShcool.DAL.EF;
using InternetShcool.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShcool.DAL.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly InternetSchoolDBContext context;
        public StudentRepository(InternetSchoolDBContext context)
        {
            this.context = context;
        }
        public async Task<bool> DeleteStudentById(int id)
        {
            try
            {
                var student = await context.Students.FindAsync(id);
                if (student != null)
                {
                    context.Students.Remove(student);
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

        public async Task<bool> DeleteStudentByName(string name)
        {
            try
            {
                var data = await context.Students.ToListAsync();
                var student = (from d in data
                             where d.Name == name
                             select d).ToList().First();
                if (student != null)
                {
                    context.Remove(student);
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

        public async Task<List<Student>> GetAllStudents()
        {
            try
            {
                var data =await context.Students.ToListAsync();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Student> GetStudentById(int id)
        {
            try
            {
                var data = await context.Students.ToListAsync();
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

        public async Task<List<Student>> GetStudentByName(string studentName)
        {
            try
            {
                var data =await context.Students.ToListAsync();
                var res = (from d in data
                           where d.Name == studentName
                           select d).ToList();
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> PostStudent(Student student)
        {
            try
            {
                await context.AddAsync(student);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateStudent(int studentId, Student student)
        {
            try
            {
                var data = await context.Students.FindAsync(studentId);
                if (data != null)
                {
                    data.Age = student.Age;
                    data.Email = student.Email;
                    data.Name = student.Name;
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
