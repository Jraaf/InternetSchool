using InternetShcool.DAL.Models;

namespace InternetScool.BLL.Service.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
}
