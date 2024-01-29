﻿using AutoMapper;
using ProgrammingPro.Server.Dtos;
using ProgrammingPro.Server.Models;

namespace ProgrammingPro.Server.Helper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
            CreateMap<Lesson, LessonDto>();
            CreateMap<LessonDto, Lesson>();
        }
    }
}
