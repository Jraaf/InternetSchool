using AutoMapper;
using InternetSchool.Models;


namespace InternetScool.BLL.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<DTO.CreateGroupDTO, Group>();
            CreateMap<Group, DTO.Out.GroupDTO>();
        }
    }
}
