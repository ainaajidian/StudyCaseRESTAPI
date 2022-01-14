using System.ComponentModel.DataAnnotations;

namespace EnrollmentService.Dtos
{
    public class CourseDto
    {
        public int CourseID { get; set; }

        public string CourseName { get; set; }

        public int TotalHours { get; set; }

    }
}
