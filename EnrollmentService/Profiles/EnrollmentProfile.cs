using AutoMapper;
using EnrollmentService.Dtos;
using EnrollmentService.Models;

namespace EnrollmentService.Profiles
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<EnrollmentCreateDto, Enrollment>();
            CreateMap<EnrollmentDto, Enrollment>();
            CreateMap<Enrollment, EnrollmentDto>();
        }
    }
}
