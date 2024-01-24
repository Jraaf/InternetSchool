using AutoMapper;
using InternetSchool.Models;
using InternetScool.Common.DTO;
using InternetScool.Common.DTO.Out;


namespace InternetScool.BLL.Profiles
{
    public class SubjectProfile:Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, CreateSubjectDTO>().ReverseMap();
            CreateMap<Subject, SubjectDTO>().ReverseMap();

        }
    }
}
