namespace Databases.DTO.Out
{
    public class TeacherOutDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int SchoolId { get; set; }
        public List<GroupDTO>? Groups { get; set; }
    }
}
