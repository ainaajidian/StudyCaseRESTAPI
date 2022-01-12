using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentService.Models;
namespace PaymentService.Data

{
    public class EnrollmentDAL : IEnrollment
    {
        private readonly ProjectRESTAPIContext _db;

        public EnrollmentDAL(ProjectRESTAPIContext db)
        {
            _db = db;
        }


        public async Task EnrollmentCreate(Enrollment enrollment)
        {
            if (enrollment == null) throw new ArgumentNullException(nameof(enrollment));
            _db.Enrollments.Add(enrollment);
            await _db.SaveChangesAsync();
        }
    }
}