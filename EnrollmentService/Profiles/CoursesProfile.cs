using AutoMapper;
using EnrollmentService.Dtos;
using EnrollmentService.Models;

namespace EnrollmentService.Profiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseDto, Course>();
            CreateMap<Course, CourseDto>();
        }
    }
}
