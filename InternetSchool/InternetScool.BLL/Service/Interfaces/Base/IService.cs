using InternetScool.Common.DTO.Out;
using InternetScool.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetScool.BLL.Service.Interfaces.Base
{
    public interface IService<T> 
        where T : class
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(int Id);
        public Task<bool> Post(T group);
        public Task<bool> Delete(int Id);
        public Task<bool> Update(T CreateDTO, int Id);
    }
}
