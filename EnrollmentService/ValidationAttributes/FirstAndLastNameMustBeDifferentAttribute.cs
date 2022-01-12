using EnrollmentService.Dtos;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentService.ValidationAttributes
{
    public class StudentFirstLastMustBeDifferentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var student = (StudentCreateDto)validationContext.ObjectInstance;
            if (student.FirstName == student.LastName)
            {
                return new ValidationResult("FirstName dan LastName tidak boleh sama",
                    new[] { nameof(StudentCreateDto) });
            }

            return ValidationResult.Success;
        }
    }
}
