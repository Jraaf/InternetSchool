using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShcool.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Login { get; set; }
        public required byte[] PasswordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }
    }
}
