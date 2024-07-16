using InternetSchool.Models;
using InternetScool.Common.DTO;
using InternetScool.Common.DTO.Out;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetScool.BLL.Service.Interfaces
{
    public interface IStudentService
    {
        public Task<List<StudentDTO>> GetAll();
        public Task<StudentDTO> GetById(int Id);
        public Task<bool> Post(CreateStudentDTO group);
        public Task<bool> Delete(int Id);
        public Task<bool> Update(CreateStudentDTO CreateDTO, int Id);
    }
}
