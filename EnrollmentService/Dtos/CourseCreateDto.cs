using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentService.Dtos
{
    public class CourseCreateDto : IValidatableObject
    {
        [Required]
        public string CourseName { get; set; }

        [Required]
        public int CourseCredits { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CourseName.Length >= 50)
            {
                yield return new ValidationResult("Tidak boleh lebih kecil dari 50 karakter",
                    new[] { "CourseName" });
            }

            if (CourseCredits >= 10)
            {
                yield return new ValidationResult("Harus lebih kecil dari angka 10",
                    new[] { "Credits" });
            }
        }
    }
}
