using Databases.Common.DTO;

namespace Databases.Service.Interfaces
{
    public interface ITeacherService
    {
        Task<List<TeacherDTO>> GetTeachers();
        Task<TeacherDTO> GetTeacherById(int Id);
        Task<bool> PostTeacher(TeacherDTO teacher);
        Task<bool> DeleteTeacher(int TeahcerId);
        Task<bool> UpdateTeacher(TeacherDTO teacher, int Id);
        Task<bool> SetTeacherToSchool(int TeacherId, int SchoolId);
        Task<bool> RemoveTeahcerFromSchool(int teacherId);        
    }
}
