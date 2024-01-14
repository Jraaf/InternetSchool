using AutoMapper;
using InternetSchool.Models;

namespace InternetScool.BLL.Profiles
{
    public class TeacherProfile:Profile
    {
        public TeacherProfile()
        {
            CreateMap<DTO.CreateTeacherDTO, Teacher>().ReverseMap();
            CreateMap<Teacher, DTO.Out.TeacherDTO>().ReverseMap();
        }
    }
}
