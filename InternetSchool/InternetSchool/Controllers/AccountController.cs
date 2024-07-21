using InternetSchool.Common.DTO;
using InternetSchool.Common.DTO.Out;
using InternetScool.BLL.Service.Interfaces;
using InternetShcool.DAL.EF;
using InternetShcool.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace InternetSchool.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(InternetSchoolDBContext _context,ITokenService _tokenService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterUserDTO dto)
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

            return new UserDTO
            {
                Login = user.Login,
                AccessToken = _tokenService.CreateToken(user)
            };
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginUserDTO dto)
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

            return new UserDTO
            {
                Login = user.Login,
                AccessToken = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string login)
        {
            return await _context.Users.AnyAsync(x =>
                x.Login.ToLower() == login.ToLower());
        }
    }
}
