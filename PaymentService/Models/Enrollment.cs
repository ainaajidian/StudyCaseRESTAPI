using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace PaymentService.Models
{
    public enum Grade
    { A, B, C, D, E }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
        public float? Invoice { get; set; }

        [JsonIgnore]
        public Course Course { get; set; }
        [JsonIgnore]
        public Student Student { get; set; }

    }
}
