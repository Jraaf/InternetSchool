using AutoMapper;
using InternetSchool.Models;
using InternetScool.Common.DTO;
using InternetScool.Common.DTO.Out;


namespace InternetScool.BLL.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<CreateGroupDTO, Group>();
            CreateMap<Group,GroupDTO>();
        }
    }
}
