using AutoMapper;
using Databases.DTO;
using Databases.DTO.Out;
using Databases.Models;

namespace Databases.Profiles
{
    public class SchoolProfile:Profile
    {
        public SchoolProfile()
        {
            CreateMap<School, SchoolDTO>().ReverseMap();
            CreateMap<School, SchoolOutDTO>().ReverseMap();
        }
    }
}
