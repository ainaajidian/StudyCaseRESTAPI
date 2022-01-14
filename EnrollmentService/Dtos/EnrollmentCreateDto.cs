using EnrollmentService.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentService.Dtos
{
    public class EnrollmentCreateDto
    {
        public int CourseID { get; set; }

        public int StudentID { get; set; }

        public Grade? Grade { get; set; }

        public float? Invoice { get; set; }
    }
}
