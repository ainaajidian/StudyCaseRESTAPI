using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Data;
using PaymentService.Dtos;
using PaymentService.Models;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/p/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private IPayment _payment;
        private readonly IMapper _mapper;
       

        public EnrollmentController(IPayment payment,
        IMapper mapper)
        {
            _payment = payment;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateEnrollment(EnrollmentCreateDto enrollment)
        {
            try
            {
                var enroll = _mapper.Map<Enrollment>(enrollment);
                await _payment.CreateEnrollemnt(enroll);
                return Ok($"Data enrollment StudentId: {enrollment.StudentID} dan CourseId: {enrollment.CourseID} berhasil ditambahkan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}