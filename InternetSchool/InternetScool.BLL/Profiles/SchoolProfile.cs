using AutoMapper;
using InternetSchool.Models;
using InternetScool.Common.DTO;
using InternetScool.Common.DTO.Out;

namespace InternetScool.BLL.Profiles
{
    public class SchoolProfile:Profile
    {
        public SchoolProfile()
        {
            CreateMap<School, CreateSchoolDTO>().ReverseMap();
            CreateMap<School, SchoolDTO>().ReverseMap();
        }
    }
}
