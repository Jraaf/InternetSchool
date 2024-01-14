using InternetScool.BLL.DTO;
using InternetScool.BLL.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InternetSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService service;
        public GroupController(IGroupService service)
        {
            this.service = service;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data=await service.GetGroups();
            if(data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await service.GetGroupById(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var data = await service.GetGroupByName(name);
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpPost("PostGroup")]
        public async Task<IActionResult> PostGroup(CreateGroupDTO group)
        {
            var data = await service.PostGroup(group);
            return data? Ok(data):BadRequest();
        }
        [HttpDelete("DeleteGroup")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var data = await service.DeleteGroup(id);
            return data ? Ok(data) : BadRequest();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateGroup(int id,CreateGroupDTO group)
        {
            var data = await service.UpdateGroup(group,id);
            return data ? Ok(data) : BadRequest();
        }
    }
}
