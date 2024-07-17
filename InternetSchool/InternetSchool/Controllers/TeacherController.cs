using InternetScool.BLL.Service.Interfaces;
using InternetScool.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using ServiceStack;

namespace InternetSchool.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;
        public TeacherController(ITeacherService service)
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
        [HttpPost("PostTeacher")]
        public async Task<IActionResult> PostTeacher(CreateTeacherDTO teacher)
        {
            var data = await _service.Post(teacher);
            return Ok(data);
        }
        [HttpDelete("DeleteTeacher")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var data = await _service.Delete(id);
            return data ? Ok(data) : BadRequest();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTeacher(int Id, CreateTeacherDTO DTO)
        {
            var data = await _service.Update(DTO,Id);
            return Ok(data);
        }
    }
}
