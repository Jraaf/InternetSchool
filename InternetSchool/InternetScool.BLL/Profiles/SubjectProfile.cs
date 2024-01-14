using AutoMapper;
using InternetSchool.Models;


namespace InternetScool.BLL.Profiles
{
    public class SubjectProfile:Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, DTO.CreateSubjectDTO>().ReverseMap();
            CreateMap<Subject, DTO.Out.SubjectDTO>().ReverseMap();

        }
    }
}
