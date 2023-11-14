using AutoMapper;
using Azure.Core;
using Databases.DTO;
using Databases.DTO.Out;
using Databases.Service;
using Databases.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Security.AccessControl;

namespace Databases.Controllers
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
        [HttpGet("GetAllTeahcers")]
        public async Task<IActionResult> GetAllTeachers()
        {
            var res = await service.GetTeachers();
            return Ok(res);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await service.GetTeacherById(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        [HttpPost("AddTeacher")]
        public async Task<IActionResult> PostTeacher(TeacherDTO teacher)
        {
            return Ok(await service.PostTeacher(teacher));
        }
        [HttpDelete("RemoveTeacher")]
        public async Task<IActionResult> DeleteTeacher(int teacherId)
        {
            return Ok(service.DeleteTeacher(teacherId));
        }
        [HttpPut("UpdateTeacher")]
        public async Task<IActionResult> UpdateTeacher(TeacherDTO teacher, int teacherId)
        {
            return Ok(service.UpdateTeacher(teacher,teacherId));
        }
        [HttpPost("RemoveTeacherFromSchool")]
        public async Task<IActionResult> RemoveTeahcerFromSchool(int teacherId)
        {
            return Ok(await service.RemoveTeahcerFromSchool(teacherId));
        }
        [HttpPost("SetTeacherToSchool")]
        public async Task<IActionResult> SetTeacherToSchool(int teacherId, int schoolId)
        {
            return Ok(await service.SetTeacherToSchool(teacherId,schoolId));
        }
        [HttpGet("GetTeachersOfSchool")]
        public async Task<IActionResult> GetTeachersOfSchool(int schoolId)
        {
            var data=await service.GetTeachersOfSchool(schoolId);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }
    }
}
