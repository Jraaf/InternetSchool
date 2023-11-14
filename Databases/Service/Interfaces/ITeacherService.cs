using Databases.DTO;
using Databases.DTO.Out;

namespace Databases.Service.Interfaces
{
    public interface ITeacherService
    {
        Task<List<TeacherOutDTO>> GetTeachers();
        Task<TeacherOutDTO> GetTeacherById(int Id);
        Task<bool> PostTeacher(TeacherDTO teacher);
        Task<bool> DeleteTeacher(int TeahcerId);
        Task<bool> UpdateTeacher(TeacherDTO teacher, int Id);
        Task<bool> RemoveTeahcerFromSchool(int teacherId);
        Task<bool> SetTeacherToSchool(int TeacherId, int SchoolId);
    }
}
