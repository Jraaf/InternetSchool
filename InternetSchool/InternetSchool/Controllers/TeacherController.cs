using InternetScool.BLL.Service.Interfaces;
using InternetScool.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InternetSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService service;
        public TeacherController(ITeacherService service)
        {
            this.service = service;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await service.GetTeachers();
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await service.GetTeacherById(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        //[HttpGet("GetByName")]
        //public async Task<IActionResult> GetByName(string name)
        //{
        //    var data = await service.GetTeacherByName(name);
        //    if (data != null)
        //    {
        //        return Ok(data);
        //    }
        //    return NoContent();
        //}
        [HttpPost("PostTeacher")]
        public async Task<IActionResult> PostTeacher(CreateTeacherDTO teacher)
        {
            var data = await service.PostTeacher(teacher);
            return data ? Ok(data) : BadRequest();
        }
        [HttpDelete("DeleteTeacher")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var data = await service.DeleteTeacherById(id);
            return data ? Ok(data) : BadRequest();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTeacher(int id, CreateTeacherDTO teacher)
        {
            var data = await service.UpdateTeacher(id, teacher);
            return data ? Ok(data) : BadRequest();
        }
    }
}
