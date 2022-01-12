using EnrollmentService.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentService.Dtos
{
    [StudentFirstLastMustBeDifferent]
    public class StudentCreateDto
    {
        [Required(ErrorMessage = "Kolom FirstName harus diisi")]
        [MaxLength(20, ErrorMessage = "Tidak boleh lebih dari 20 karakter")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Kolom LastName harus diisi")]
        [MaxLength(20, ErrorMessage = "Tidak boleh lebih dari 20 karakter")]
        public string LastName { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }
    }
}
