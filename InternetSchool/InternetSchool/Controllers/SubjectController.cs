using InternetScool.BLL.DTO;
using InternetScool.BLL.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InternetSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService service;
        public SubjectController(ISubjectService service)
        {
            this.service = service;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await service.GetSubjects();
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await service.GetSubjectById(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var data = await service.GetSubjectByName(name);
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpPost("PostSubject")]
        public async Task<IActionResult> PostSubject(CreateSubjectDTO subject)
        {
            var data = await service.PostSubject(subject);
            return data ? Ok(data) : BadRequest();
        }
        [HttpDelete("DeleteSubject")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var data = await service.DeleteSubjectById(id);
            return data ? Ok(data) : BadRequest();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateSubject(int id, CreateSubjectDTO subject)
        {
            var data = await service.UpdateSubject(id, subject);
            return data ? Ok(data) : BadRequest();
        }
    }
}
