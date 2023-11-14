﻿using AutoMapper;
using Databases.Common.DTO;
using Databases.Models;

namespace Databases.Profiles
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentDTO, Student>().ReverseMap();
        }
    }
}
