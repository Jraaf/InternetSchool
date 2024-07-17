using InternetScool.BLL.Service.Interfaces;
using InternetScool.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InternetSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _service;
        public SubjectController(ISubjectService service)
        {
            this._service = service;
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
        [HttpPost("PostSubject")]
        public async Task<IActionResult> Post(CreateSubjectDTO subject)
        {
            var data = await _service.Post(subject);
            return Ok(data);
        }
        [HttpDelete("DeleteSubject")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var data = await _service.Delete(id);
            return data ? Ok(data) : BadRequest();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateSubject(int id, CreateSubjectDTO DTO)
        {
            var data = await _service.Update(DTO, id);
            return Ok(data);
        }
    }
}
