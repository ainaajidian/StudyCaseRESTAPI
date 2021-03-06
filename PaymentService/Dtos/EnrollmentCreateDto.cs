using PaymentService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentService.Dtos
{
    public class EnrollmentCreateDto
    {
        [Required]
        public int CourseID { get; set; }

        [Required]
        public int StudentID { get; set; }

        [Required]
        public Grade? Grade { get; set; }

        [Required]
        public float? Invoice { get; set; }
    }
}