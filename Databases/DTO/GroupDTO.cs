
namespace Databases.DTO
{
    public class GroupDTO
    {
        public string Name { get; set; }
        public SubjectDTO? subject { get; set; }
        public List<StudentDTO>? Students { get; set; }
        public TeacherDTO? Teacher { get; set; }
    }
}
