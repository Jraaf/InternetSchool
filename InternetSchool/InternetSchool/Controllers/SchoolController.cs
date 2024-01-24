using InternetScool.BLL.Service.Interfaces;
using InternetScool.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InternetSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService service;
        public SchoolController(ISchoolService service)
        {
            this.service = service;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await service.GetSchools();
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await service.GetSchoolById(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var data = await service.GetSchoolByName(name);
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpPost("PostSchool")]
        public async Task<IActionResult> PostSchool(CreateSchoolDTO group)
        {
            var data = await service.PostSchool(group);
            return data ? Ok(data) : BadRequest();
        }
        [HttpDelete("DeleteSchool")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            var data = await service.DeleteSchool(id);
            return data ? Ok(data) : BadRequest();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateSchool(int id, CreateSchoolDTO group)
        {
            var data = await service.UpdateSchool(group, id);
            return data ? Ok(data) : BadRequest();
        }
    }
}
