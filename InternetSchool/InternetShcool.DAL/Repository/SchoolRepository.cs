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
    public class SchoolRepository : ISchoolRepository
    {
        private readonly InternetSchoolDBContext context;
        public SchoolRepository(InternetSchoolDBContext context)
        {
            this.context = context;
        }
        public async Task<bool> DeleteSchoolById(int id)
        {
            try
            {
                var school = await context.Schools.FindAsync(id);
                if (school != null)
                {
                    context.Schools.Remove(school);
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

        public async Task<bool> DeleteSchoolByName(string name)
        {
            try
            {
                var data = context.Schools.ToList();
                var school = (from d in data
                             where d.Name == name
                             select d).ToList().First();
                if (school != null)
                {
                    context.Remove(school);
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

        public async Task<List<School>> GetAllSchools()
        {
            try
            {
                var data = context.Schools.ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<School> GetSchoolById(int id)
        {
            try
            {
                var res = await context.Schools.FindAsync(id);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<School>> GetSchoolByName(string schoolName)
        {
            try
            {
                var data = context.Schools.ToList();
                var res = (from d in data
                           where d.Name == schoolName
                           select d).ToList();
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> PostSchool(School school)
        {
            try
            {
                await context.AddAsync(school);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateSchool(int schoolId, School school)
        {
            try
            {
                var data = await context.Schools.FindAsync(schoolId);
                if (data != null)
                {
                    data.Name = school.Name;
                    data.Description = school.Description;
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
