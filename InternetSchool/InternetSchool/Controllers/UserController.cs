using AutoMapper.Configuration.Annotations;
using InternetSchool.Common.DTO;
using InternetShcool.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace InternetSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static User user =new User();

        private readonly IConfiguration _configuration;
        private const string TokenSecret = "hfgdasjlkfhsdlahfkljslasdsagkfjgsdakjhbbcashgdasjghfhsjvsadgjfsdajfvsadjfhfywera";
        private readonly TimeSpan _expiresIn=TimeSpan.FromHours(8);
        public UserController(IConfiguration configuration)
        {

            _configuration = configuration;

        }
        [HttpPost("register")]
        public ActionResult<CreateUserDTO> Register(CreateUserDTO request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.Login=request.Login;
            user.PasswordHash=passwordHash;
            return Ok(user);
        }
        [HttpPost("login")]
        public ActionResult<CreateUserDTO> Login(CreateUserDTO request)
        {
            if(user.Login!=request.Login)
            {
                return BadRequest("User not found");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return BadRequest("Wrong password");
            }
            var token = CreateToken(user);
            return Ok(token);
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.Login)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);


            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials:creds
                );
            var jwt=new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
