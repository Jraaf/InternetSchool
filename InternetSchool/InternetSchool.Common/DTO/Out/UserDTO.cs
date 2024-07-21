using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetSchool.Common.DTO.Out;

public class UserDTO
{
    //public required int Id { get; set; }
    public required string Login { get; set; } 
    public required string AccessToken { get; set; }
}
