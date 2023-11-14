namespace Databases.DTO.Out
{
    public class GroupOutDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SubjectDTO? subject { get; set; }
        public List<StudentDTO>? Students { get; set; }
        public TeacherDTO? Teacher { get; set; }
    }
}
