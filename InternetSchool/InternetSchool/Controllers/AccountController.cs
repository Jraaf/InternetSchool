using InternetSchool.Common.DTO;
using InternetShcool.DAL.EF;
using InternetShcool.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace InternetSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        InternetSchoolDBContext _context;
        public AccountController(InternetSchoolDBContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterUserDTO dto)
        {
            if (await UserExists(dto.Login))
            {
                return BadRequest("Login is taken");
            }
            using var hmac = new HMACSHA512();

            var user = new User()
            {
                Login = dto.Login,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
                PasswordSalt = hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(LoginUserDTO dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x =>
                x.Login.ToLower() == dto.Login.ToLower());

            if (user == null)
                return Unauthorized($"User {dto.Login} not found");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                    return Unauthorized("Wrong password");
            }
            return Ok(user);
             
        }

        private async Task<bool> UserExists(string login)
        {
            return await _context.Users.AnyAsync(x =>
                x.Login.ToLower() == login.ToLower());
        }
    }
}
