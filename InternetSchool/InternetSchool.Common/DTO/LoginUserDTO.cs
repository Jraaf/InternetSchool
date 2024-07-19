using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetSchool.Common.DTO;

public class LoginUserDTO
{
    public required string Login { get; set; }
    public required string Password { get; set; }
}
