using AutoMapper;
using Databases.Common.DTO;
using Databases.Models;

namespace Databases.Profiles
{
    public class SchoolProfile:Profile
    {
        public SchoolProfile()
        {
            CreateMap<School, SchoolDTO>().ReverseMap();
        }
    }
}
