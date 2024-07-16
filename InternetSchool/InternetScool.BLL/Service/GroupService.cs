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
        private readonly IMapper mapper;
        private readonly IRepository<Group> repo;
        public GroupService(IRepository<Group> repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<bool> Delete(int Id)
        {
            var group=repo.FirstOrDefault(s=>s.Id==Id)
                ?? throw new Exception("There is no such group");
            return await repo.DeleteAsync(group);
        }

        public async Task<GroupDTO> GetById(int Id)
        {
            var group = await repo.FirstAsync(s => s.Id == Id)
                ?? throw new NotFoundException(Id);
            var res=mapper.Map<GroupDTO>(group);
            return res;
        }

        public async Task<List<GroupDTO>> GetAll()
        {
            var data = await repo.GetAllAsync();
            return mapper.Map<List<GroupDTO>>(data);
        }

        public async Task<bool> Post(CreateGroupDTO group)
        {
           var data = mapper.Map<Group>(group);
           return await repo.AddAsync(data);
        }

        public async Task<bool> Update(CreateGroupDTO group, int Id)
        {
            var data = mapper.Map<Group>(group);
            return await repo.UpdateAsync(data,Id);
        }
    }
}
