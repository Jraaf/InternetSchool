using InternetScool.BLL.Service.Interfaces;
using InternetShcool.DAL.Models;
using Microsoft.Extensions.Configuration;

namespace InternetScool.BLL.Service;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    public TokenService(IConfiguration config)
    {
        _config = config;
    }
    public string CreateToken(User user)
    {
        var token = _config["TokenKey"] ?? throw new Exception("cannot access token key");
        if (token.Length < 64) throw new Exception("too short key");
    }
}
