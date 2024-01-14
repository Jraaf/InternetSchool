using InternetScool.BLL.DTO;
using InternetScool.BLL.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService service;
        public StudentController(IStudentService service)
        {
            this.service = service;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await service.GetAllStudents();
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await service.GetStudentById(id);
            if (data == null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var data = await service.GetStudentByName(name);
            if (data == null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpPost("PostStudent")]
        public async Task<IActionResult> PostStudent(CreateStudentDTO group)
        {
            var data = await service.PostStudent(group);
            return data ? Ok(data) : BadRequest();
        }
        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var data = await service.DeleteStudentById(id);
            return data ? Ok(data) : BadRequest();
        }
        [HttpDelete("DeleteStudentByName")]
        public async Task<IActionResult> DeleteStudentByName(string name)
        {
            var data = await service.DeleteStudentByName(name);
            return data ? Ok(data) : BadRequest();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateStudent(int id, CreateStudentDTO group)
        {
            var data = await service.UpdateStudent(id,group);
            return data ? Ok(data) : BadRequest();
        }
    }
}
