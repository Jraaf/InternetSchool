﻿using InternetScool.BLL.Service.Interfaces;
using InternetScool.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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
            var data = await service.GetAll();
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await service.GetById(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var data = await service.GetByName(name);
            if (data != null)
            {
                return Ok(data);
            }
            return NoContent();
        }
        [HttpPost("PostGroup")]
        public async Task<IActionResult> Post(CreateGroupDTO group)
        {
            var data = await service.Post(group);
            return Ok(data);
        }
        [HttpDelete("DeleteGroup")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await service.Delete(id);
            return data ? Ok(data) : BadRequest();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, CreateGroupDTO DTO)
        {
            var data = await service.Update(DTO, id);
            return Ok(data);
        }
    }
}
