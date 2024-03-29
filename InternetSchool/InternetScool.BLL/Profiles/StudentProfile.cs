﻿using AutoMapper;
using InternetSchool.Models;
using InternetScool.Common.DTO;

namespace InternetScool.BLL.Profiles
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<CreateStudentDTO, Student>().ReverseMap();
            CreateMap<CreateStudentDTO, Student>().ReverseMap();

        }
    }
}
