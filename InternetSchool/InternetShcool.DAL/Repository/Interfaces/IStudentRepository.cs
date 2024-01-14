using InternetSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShcool.DAL.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task<List<Student>> GetStudentByName(string groupName);
        Task<bool> PostStudent(Student group);
        Task<bool> DeleteStudentById(int id);
        Task<bool> DeleteStudentByName(string group);
        Task<bool> UpdateStudent(int id, Student group);
    }
}
