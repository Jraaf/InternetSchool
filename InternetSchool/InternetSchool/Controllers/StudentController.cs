using InternetScool.BLL.Service.Interfaces;
using InternetScool.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InternetSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
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
        [HttpPost("PostStudent")]
        public async Task<IActionResult> Post(CreateStudentDTO group)
        {
            var data = await _service.Post(group);
            return Ok(data);
        }
        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.Delete(id);
            return data ? Ok(data) : BadRequest();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, CreateStudentDTO DTO)
        {
            var data = await _service.Update(DTO, id);
            return Ok(data);
        }
    }
}
