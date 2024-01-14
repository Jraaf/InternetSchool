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
    public class SubjectRepository: ISubjectRepository
    {
        private readonly InternetSchoolDBContext context;
        public SubjectRepository(InternetSchoolDBContext context)
        {
            this.context = context;
        }
        public async Task<bool> DeleteSubjectById(int id)
        {
            try
            {
                var subject = await context.Subjects.FindAsync(id);
                if (subject != null)
                {
                    context.Subjects.Remove(subject);
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

        public async Task<bool> DeleteSubjectByName(string name)
        {
            try
            {
                var data = context.Subjects.ToList();
                var subject = (from d in data
                             where d.Name == name
                             select d).ToList().First();
                if (subject != null)
                {
                    context.Remove(subject);
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

        public async Task<List<Subject>> GetAllSubjects()
        {
            try
            {
                var data = context.Subjects.ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            try
            {
                var data = context.Subjects.ToList();
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

        public async Task<Subject> GetSubjectByName(string subjectName)
        {
            try
            {
                var data = context.Subjects.ToList();
                var res = (from d in data
                           where d.Name == subjectName
                           select d).ToList().First();
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> PostSubject(Subject subject)
        {
            try
            {
                await context.AddAsync(subject);
                context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateSubject(int subjectId, Subject subject)
        {
            try
            {
                var data = await context.Subjects.FindAsync(subjectId);
                if (data != null)
                {
                    data.Name = subject.Name;
                    data.Description = subject.Description;
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
