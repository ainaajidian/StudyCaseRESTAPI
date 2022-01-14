using PaymentService.Models;
using System.Collections.Generic;

namespace PaymentService.Dtos
{
    public class PaymentDto
    {
        public string Fullname { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
