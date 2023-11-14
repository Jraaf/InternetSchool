using Databases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Databases.DTO
{
    public class TeacherDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int SchoolId { get; set; }
        public List<GroupDTO>? Groups { get; set; }
    }
}
