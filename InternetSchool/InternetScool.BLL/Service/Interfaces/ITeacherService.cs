using InternetScool.Common.DTO;
using InternetScool.Common.DTO.Out;

namespace InternetScool.BLL.Service.Interfaces
{
    public interface ITeacherService
    {
        Task<List<TeacherDTO>> GetTeachers();
        Task<TeacherDTO> GetTeacherById(int Id);
        Task<bool> PostTeacher(CreateTeacherDTO teacher);
        Task<bool> DeleteTeacherById(int TeahcerId);
        Task<bool> UpdateTeacher(int Id, CreateTeacherDTO teacher);
        //Task<bool> RemoveTeahcerFromSchool(int teacherId);
        //Task<bool> SetTeacherToSchool(int TeacherId, int SchoolId);
        //Task<List<TeacherDTO>> GetTeachersOfSchool(int schoolId);
    }
}
