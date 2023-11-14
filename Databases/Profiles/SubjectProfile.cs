using AutoMapper;
using Databases.Common.DTO;
using Databases.Models;

namespace Databases.Profiles
{
    public class SubjectProfile:Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject,SubjectDTO>().ReverseMap();
        }
    }
}
