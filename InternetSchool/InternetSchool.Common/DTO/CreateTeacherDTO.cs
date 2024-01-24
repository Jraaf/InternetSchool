using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InternetScool.Common.DTO
{
    public class CreateTeacherDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int SchoolId { get; set; }
    }
}
