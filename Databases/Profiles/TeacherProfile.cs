using AutoMapper;
using Databases.DTO;
using Databases.DTO.Out;
using Databases.Models;

namespace Databases.Profiles
{
    public class TeacherProfile:Profile
    {
        public TeacherProfile()
        {
            CreateMap<TeacherDTO, Teacher>().ReverseMap();
            CreateMap<Teacher, TeacherOutDTO>().ReverseMap();
        }
    }
}
