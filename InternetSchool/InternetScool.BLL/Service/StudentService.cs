using AutoMapper;
using InternetShcool.DAL.Repository.Interfaces;
using InternetSchool.Models;
using InternetScool.BLL.Service.Interfaces;
using InternetScool.Common.DTO.Out;
using InternetScool.Common.DTO;
using InternetSchool.Common.Exceptions;

namespace InternetScool.BLL.Service
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<bool> Delete(int Id)
        {
            var data = await _repo.GetAsync(Id);
            if (data != null)
            {
                return await _repo.DeleteAsync(data);
            }
            throw new Exception("There is no such group");
        }

        public async Task<StudentDTO> GetById(int Id)
        {
            var data = await _repo.GetAsync(Id);
            if (data != null)
            {
                return _mapper.Map<StudentDTO>(data);
            }
            throw new NotFoundException(Id);
        }

        public async Task<List<StudentDTO>> GetAll()
        {
            var data = await _repo.GetAllAsync();
            return _mapper.Map<List<StudentDTO>>(data);
        }

        public async Task<StudentDTO> Post(CreateStudentDTO group)
        {
            var data = _mapper.Map<Student>(group);
            var res = await _repo.AddAsync(data);

            return _mapper.Map<StudentDTO>(res);
        }

        public async Task<StudentDTO> Update(CreateStudentDTO group, int Id)
        {
            var data = _mapper.Map<Student>(group);
            var entity = await _repo.GetAsync(Id);

            if (entity != null)
            {
                entity = data;
                entity.Id = Id;
                var res = await _repo.UpdateAsync(entity);
            }

            throw new NotFoundException(Id);
        }

        public async Task<List<StudentDTO>> GetByName(string Name)
        {
            var data = await _repo.GetByName(Name);
            if (data != null)
            {
                return _mapper.Map<List<StudentDTO>>(data);
            }
            throw new NotFoundException(Name);
        }
    }
}
