using AutoMapper;
using Databases.Common.DTO;
using Databases.DTO;
using System.Text.RegularExpressions;

namespace Databases.Profiles
{
    public class GroupProfile:Profile
    {
        public GroupProfile()
        {
            CreateMap<GroupDTO, Group>().ReverseMap();
        }
    }
}
