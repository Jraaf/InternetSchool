using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetSchool.Common.DTO;

public class RegisterUserDTO
{
    public required string Login { get; set; }
    public required string Password { get; set; }
}
