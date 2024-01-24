using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetScool.Common.DTO
{
    public class CreateStudentDTO
    {
        public string Name { get; set; }
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        public int GroupId { get; set; }
    }
}
