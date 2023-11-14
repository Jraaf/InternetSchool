using AutoMapper;
using Databases.Common.DTO;
using Databases.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Databases.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : Controller
    {
        private readonly ISchoolService service;
        public SchoolController(ISchoolService service)
        {
            this.service = service;
        }
        [HttpGet("GetAllSchools")]
        public async Task<IActionResult> GetAll()
        {
            var res = await service.GetSchools();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetSchoolById(int Id)
        {
            var res = await service.GetSchoolById(Id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        [HttpPost("AddSchool")]
        public async Task<IActionResult> AddSchool(SchoolDTO shool)
        {
            var res = await service.PostSchool(shool);
            return Ok(res);
        }
        [HttpDelete("DeleteSchool")]
        public async Task<IActionResult> DeleteSchool(int schoolId)
        {
            var res = await service.DeleteSchool(schoolId);
            return Ok(res);
        }
        [HttpPut("UpdateSchool")]
        public async Task<IActionResult> UpdateSchool(SchoolDTO school,int schoolId)
        {
            var res= await service.UpdateSchool(school,schoolId);
            return Ok(res);
        }
    }
}
