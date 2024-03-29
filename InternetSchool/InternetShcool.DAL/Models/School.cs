﻿ using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InternetSchool.Models
{
    public class School
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }=string.Empty;
        public List<Teacher> Teachers { get; set; } = new();
    }
}
