﻿using AutoMapper;

using InternetScool.BLL.Service.Interfaces;

using InternetSchool.DAL.Repository.Interfaces;
using InternetSchool.Models;
using InternetScool.Common.DTO.Out;
using InternetScool.Common.DTO;
using InternetSchool.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InternetScool.BLL.Service
{
    public class SubjectService : ISubjectService
    {
        private readonly IMapper _mapper;
        private readonly ISubjectRepository _repo;
        public SubjectService(ISubjectRepository repo, IMapper mapper)
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

        public async Task<SubjectDTO> GetById(int Id)
        {
            var data = await _repo.GetAsync(Id);
            if (data != null)
            {
                return _mapper.Map<SubjectDTO>(data);
            }

            throw new NotFoundException(Id);
        }

        public async Task<List<SubjectDTO>> GetAll()
        {
            var data = await _repo.GetAllAsync();
            return _mapper.Map<List<SubjectDTO>>(data);
        }

        public async Task<SubjectDTO> Post(CreateSubjectDTO group)
        {
            var data = _mapper.Map<Subject>(group);
            var res = await _repo.AddAsync(data);

            return _mapper.Map<SubjectDTO>(res);
        }

        public async Task<SubjectDTO> Update(CreateSubjectDTO DTO, int Id)
        {
            var entity = await _repo.GetAsync(Id)
                ?? throw new NotFoundException(Id);

            entity.Id = Id;
            entity.Name = DTO.Name;
            entity.Description = DTO.Description;

            return _mapper.Map<SubjectDTO>(await _repo.UpdateAsync(entity));
        }

        public async Task<List<SubjectDTO>> GetByName(string Name)
        {
            var data = await _repo.GetByName(Name);
            if (data != null)
            {
                return _mapper.Map<List<SubjectDTO>>(data);
            }
            throw new NotFoundException(Name);
        }
    }
}
