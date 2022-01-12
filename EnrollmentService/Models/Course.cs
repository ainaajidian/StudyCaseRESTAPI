using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EnrollmentService.Models
{
    public partial class Course
    {
        public int CourseID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }

        [Required]
        public int CourseCredits { get; set; }

        [Required]
        public double CoursePrice{ get; set; }


        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
