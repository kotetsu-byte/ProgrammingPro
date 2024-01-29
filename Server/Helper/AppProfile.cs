using AutoMapper;
using ProgrammingPro.Shared.Dtos;
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
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<UserCourse, UserCourseDto>();
            CreateMap<UserCourseDto, UserCourse>();
        }
    }
}
