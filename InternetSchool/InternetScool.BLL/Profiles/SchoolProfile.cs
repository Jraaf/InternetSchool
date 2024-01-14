using AutoMapper;
using InternetSchool.Models;

namespace InternetScool.BLL.Profiles
{
    public class SchoolProfile:Profile
    {
        public SchoolProfile()
        {
            CreateMap<School, DTO.CreateSchoolDTO>().ReverseMap();
            CreateMap<School, DTO.Out.SchoolDTO>().ReverseMap();
        }
    }
}
