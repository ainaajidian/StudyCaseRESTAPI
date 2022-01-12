using System;
using System.Collections.Generic;

#nullable disable

namespace PaymentService.Models
{
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int CourseCredits { get; set; }
        public double CoursePrice { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
