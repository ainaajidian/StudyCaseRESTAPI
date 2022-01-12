using AutoMapper;
using EnrollmentService.Dtos;

namespace EnrollmentService.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<Models.Student, StudentDto>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<StudentCreateDto, Models.Student>();
        }
    }
}
