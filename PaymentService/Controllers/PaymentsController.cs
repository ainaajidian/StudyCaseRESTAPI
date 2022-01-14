using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Data;
using PaymentService.Dtos;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPayment _payment;
        private readonly IMapper _mapper;

        public PaymentController(IPayment payment,
        IMapper mapper)
        {
            _payment = payment;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PaymentDto>> GetAllBills(string name)
        {
            var results = await _payment.GetTagihan(name);
            var dtos = _mapper.Map<IEnumerable<PaymentDto>>(results);
            return dtos;
        }
    }
}