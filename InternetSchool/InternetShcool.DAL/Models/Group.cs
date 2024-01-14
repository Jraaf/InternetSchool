using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InternetSchool.Models;

public class Group
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public int SubjectId { get; set; }

    public int TeacherId { get; set; }

    public List<Student>? Students { get; set; } = new();

    [ForeignKey(nameof(SubjectId))]
    public Subject? Subject { get; set; } = null!;

    [ForeignKey(nameof(TeacherId))]
    public Teacher? Teacher { get; set; } = null!;
}
