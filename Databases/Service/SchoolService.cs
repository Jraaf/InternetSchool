using AutoMapper;
using Databases.Common.DTO;
using Databases.Models;
using Databases.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Databases.Service
{
    public class SchoolService : ISchoolService
    {
        private readonly InternetSchoolDBContext context;
        private readonly IMapper mapper;
        public SchoolService(InternetSchoolDBContext context,IMapper mapper)
        {
            this.context = context;    
            this.mapper = mapper;
        }

        public async Task<List<SchoolDTO>> GetSchools()
        {
            var _data= await context.Schools.ToListAsync();
            var _response=mapper.Map<List<School>,List<SchoolDTO>>(_data);
            return _response;
        }

        public async Task<SchoolDTO> GetSchoolById(int ShcoolId)
        {
            SchoolDTO _response = new SchoolDTO();
            var _data = await context.Schools.FindAsync(ShcoolId);
            if (_data != null)
            {
                _response = mapper.Map<School, SchoolDTO>(_data);
            }

            return _response;
        }

        public async Task<bool> PostSchool(SchoolDTO school)
        {
            try
            {
                var data= mapper.Map<SchoolDTO, School>(school);
                await context.Schools.AddAsync(data);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteSchool(int SchoolId)
        {
            try
            {
                var _school=await context.Schools.FindAsync(SchoolId);
                if (_school != null)
                {
                    context.Schools.Remove(_school);
                }
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateSchool(SchoolDTO school, int SchoolId)
        {
            try
            {
                var _school = await context.Schools.FindAsync(SchoolId);
                if (_school != null)
                {
                    var newSchool = mapper.Map<SchoolDTO, School>(school);
                    _school.Name=newSchool.Name;
                    _school.Description=newSchool.Description;
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<int> GetSchoolID(string SchoolName)
        {
            var schools = await context.Schools.ToListAsync();
            School s = schools.Find(s=>s.Name==SchoolName);
            if (s != null)
            {
                return s.Id;
            }
            return -1;
        }
    }
}
