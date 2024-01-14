using InternetSchool.Models;
using InternetScool.BLL.DTO;
using InternetScool.BLL.DTO.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetScool.BLL.Service.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDTO>> GetAllStudents();
        Task<StudentDTO> GetStudentById(int id);
        Task<List<StudentDTO>> GetStudentByName(string studentName);
        Task<bool> PostStudent(CreateStudentDTO student);
        Task<bool> DeleteStudentById(int id);
        Task<bool> DeleteStudentByName(string student);
        Task<bool> UpdateStudent(int id, CreateStudentDTO student);
    }
}
