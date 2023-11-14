using AutoMapper;
using Databases.Common.DTO;
using Databases.Models;

namespace Databases.Profiles
{
    public class TeacherProfile:Profile
    {
        public TeacherProfile()
        {
            CreateMap<TeacherDTO, Teacher>().ReverseMap();
        }
    }
}
