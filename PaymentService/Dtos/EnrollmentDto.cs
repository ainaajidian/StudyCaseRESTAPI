using PaymentService.Models;
using System.ComponentModel.DataAnnotations;

namespace PaymentService.Dtos
{
    public class EnrollmentDto
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
        public float? Invoice { get; set; }
    }
}