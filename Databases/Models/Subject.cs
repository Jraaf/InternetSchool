using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Databases.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;

        public List<Group> Groups { get; set; } = new();
    }
}
