using InternetScool.BLL.Service.Interfaces;
using InternetScool.Common.DTO;
using InternetSchool.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternetSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _service;
        public SchoolController(ISchoolService service)
        {
            _service = service;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAll();
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetById(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var data = await _service.GetByName(name);
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpPost("action")]
        public async Task<IActionResult> Post(CreateSchoolDTO group)
        {
            var data = await _service.Post(group);
            return Ok(data);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.Delete(id);
            return data ? Ok(data) : BadRequest();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, CreateSchoolDTO DTO)
        {
            var data = await _service.Update(DTO, id);
            return Ok(data);
        }
    }
}
