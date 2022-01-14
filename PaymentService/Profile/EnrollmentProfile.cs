using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace PaymentService.Profiles
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {

            CreateMap<Dtos.EnrollmentCreateDto, Models.Enrollment>();

            CreateMap<Models.Enrollment, Dtos.EnrollmentDto>();
            CreateMap<Dtos.EnrollmentDto, Models.Enrollment>();
        }
    }
}