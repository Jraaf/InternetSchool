using AutoMapper;
using InternetScool.BLL.Service.Interfaces;
using InternetSchool.Models;
using InternetShcool.DAL.Repository.Interfaces;
using InternetScool.Common.DTO;
using InternetScool.Common.DTO.Out;


namespace InternetScool.BLL.Service
{
    public class GroupService : IGroupService
    {
        private readonly IMapper mapper;
        private readonly IGroupRepository repo;
        public GroupService(IGroupRepository repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<bool> DeleteGroup(int GroupId)
        {
            return await repo.DeleteGroupById(GroupId);
        }

        public async Task<GroupDTO> GetGroupById(int GroupId)
        {
            var data=await repo.GetGroupById(GroupId);
            return mapper.Map<GroupDTO>(data);
        }

        public async Task<List<GroupDTO>> GetGroupByName(string Name)
        {
            var res=mapper.Map<List<GroupDTO>>(await repo.GetGroupByName(Name));
            return res;
        }

        public async Task<List<GroupDTO>> GetGroups()
        {
            var data = await repo.GetAllGroups();
            return mapper.Map<List<GroupDTO>>(data);
        }

        public async Task<bool> PostGroup(CreateGroupDTO group)
        {
           var data = mapper.Map<Group>(group);
           return await repo.PostGroup(data);
        }

        public async Task<bool> UpdateGroup(CreateGroupDTO group, int Id)
        {
            var data = mapper.Map<Group>(group);
            return await repo.UpdateGroup(Id, data);
        }
    }
}
