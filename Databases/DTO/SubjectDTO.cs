using Databases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databases.DTO
{
    public class SubjectDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<GroupDTO> TeacherDTO { get; set; }
    }
}
