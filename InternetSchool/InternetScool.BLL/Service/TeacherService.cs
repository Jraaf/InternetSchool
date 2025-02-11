using AutoMapper;
using InternetScool.BLL.Service.Interfaces;
using InternetSchool.Models;
using InternetSchool.DAL.Repository.Interfaces;
using InternetScool.Common.DTO.Out;
using InternetScool.Common.DTO;
using InternetSchool.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace InternetScool.BLL.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly IMapper _mapper;
        private readonly ITeacherRepository _repo;
        public TeacherService(ITeacherRepository repo, IMapper mapper)
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

            throw new NotFoundException(Id);
        }

        public async Task<TeacherDTO> GetById(int Id)
        {
            var data = await _repo.GetAsync(Id);
            if (data != null)
            {
                return _mapper.Map<TeacherDTO>(data);
            }

            throw new NotFoundException(Id);
        }

        public async Task<List<TeacherDTO>> GetAll()
        {
            var data = await _repo.GetAllAsync();
            return _mapper.Map<List<TeacherDTO>>(data);
        }

        public async Task<TeacherDTO> Post(CreateTeacherDTO DTO)
        {
            var data = _mapper.Map<Teacher>(DTO);
            var res = await _repo.AddAsync(data);

            return _mapper.Map<TeacherDTO>(res);
        }

        public async Task<TeacherDTO> Update(CreateTeacherDTO DTO, int Id)
        {
            var entity = await _repo.GetAsync(Id)
                ??throw new NotFoundException(Id);

            entity.Id = Id;
            entity.Name = DTO.Name;
            entity.Description = DTO.Description;
            entity.SchoolId = DTO.SchoolId;

            return _mapper.Map<TeacherDTO>(await _repo.UpdateAsync(entity));
        }

        public async Task<List<TeacherDTO>> GetByName(string Name)
        {
            var data = await _repo.GetByName(Name);
            if (data != null)
            {
                return _mapper.Map<List<TeacherDTO>>(data);
            }
            throw new NotFoundException(Name);
        }
    }
}
