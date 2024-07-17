using AutoMapper;
using InternetScool.BLL.Service.Interfaces;
using InternetShcool.DAL.Repository.Interfaces;
using InternetSchool.Models;
using InternetScool.Common.DTO.Out;
using InternetScool.Common.DTO;
using InternetSchool.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace InternetScool.BLL.Service
{
    public class SchoolService : ISchoolService
    {
        private readonly IMapper _mapper;
        private readonly ISchoolRepository _repo;
        public SchoolService(ISchoolRepository repo, IMapper mapper)
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

        public async Task<SchoolDTO> GetById(int Id)
        {
            var data = await _repo.GetAsync(Id);
            if (data != null)
            {
                var res = _mapper.Map<SchoolDTO>(data);
                return res;
            }
            throw new NotFoundException(Id);
        }

        public async Task<List<SchoolDTO>> GetAll()
        {
            var data = await _repo.GetAllAsync();
            return _mapper.Map<List<SchoolDTO>>(data);
        }

        public async Task<SchoolDTO> Post(CreateSchoolDTO DTO)
        {
            var data = _mapper.Map<School>(DTO);
            return _mapper.Map<SchoolDTO>(await _repo.AddAsync(data));
        }

        public async Task<SchoolDTO> Update(CreateSchoolDTO DTO, int Id)
        {
            var data = _mapper.Map<School>(DTO);
            var entity = await _repo.GetAsync(Id)
                ?? throw new NotFoundException(Id);

            entity = data;
            entity.Id = Id;

            return _mapper.Map<SchoolDTO>(await _repo.UpdateAsync(data));
        }

        public async Task<List<SchoolDTO>> GetByName(string Name)
        {
            var data = await _repo.GetByName(Name);
            if (data != null)
            {
                return _mapper.Map<List<SchoolDTO>>(data);
            }
            throw new NotFoundException(Name);
        }
    }
}
