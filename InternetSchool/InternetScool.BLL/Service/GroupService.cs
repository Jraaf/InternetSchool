using AutoMapper;
using InternetScool.BLL.Service.Interfaces;
using InternetSchool.Models;
using InternetShcool.DAL.Repository.Interfaces;
using InternetScool.Common.DTO;
using InternetScool.Common.DTO.Out;
using Microsoft.Identity.Client;
using InternetSchool.Common.Exceptions;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore;


namespace InternetScool.BLL.Service
{
    public class GroupService : IGroupService
    {
        private readonly IMapper _mapper;
        private readonly IGroupRepository _repo;
        public GroupService(IGroupRepository repo, IMapper mapper)
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

        public async Task<GroupDTO> GetById(int Id)
        {
            var data = await _repo.GetAsync(Id);
            return _mapper.Map<GroupDTO>(data);
        }

        public async Task<List<GroupDTO>> GetAll()
        {
            var data = await _repo.GetAllAsync();
            return _mapper.Map<List<GroupDTO>>(data);
        }

        public async Task<GroupDTO> Post(CreateGroupDTO group)
        {
            var data = _mapper.Map<Group>(group);
            var res = await _repo.AddAsync(data);
            return _mapper.Map<GroupDTO>(res);
        }

        public async Task<GroupDTO> Update(CreateGroupDTO DTO, int Id)
        {
            var entity = await _repo.GetAsync(Id)
                ?? throw new NotFoundException(Id);

            entity.SubjectId = DTO.SubjectId;
            entity.TeacherId = DTO.TeacherId;
            entity.Name = DTO.Name;
            entity.Id = Id;

            var res = await _repo.UpdateAsync(entity);
            return _mapper.Map<GroupDTO>(res);

        }

        public async Task<List<GroupDTO>> GetByName(string Name)
        {
            var data = await _repo.GetByName(Name);
            if (data != null)
            {
                return _mapper.Map<List<GroupDTO>>(data);
            }
            throw new NotFoundException(Name);
        }
    }
}
