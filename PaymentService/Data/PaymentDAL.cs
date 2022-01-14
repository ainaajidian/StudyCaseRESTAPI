using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentService.Models;
namespace PaymentService.Data

{
    public class PaymentDAL : IPayment
    {
        private AppDbContext _db;

        public PaymentDAL(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Enrollment> GetById(int id)
        {
            var result = await (from c in _db.Enrollments
                                where c.StudentID == id
                                select c).SingleOrDefaultAsync();
            if (result == null) throw new Exception($"Data id {id} tidak ditemukan !");

            return result;
        }

        public async Task<IEnumerable<Student>> GetTagihan(string name)
        {
            var results = await (from a in _db.Students.Include(e => e.Enrollments)
                                 where a.FirstName.ToLower().Contains(name.ToLower())
                                 || a.LastName.ToLower().Contains(name.ToLower())
                                 orderby a.StudentID ascending
                                 select a).ToListAsync();
            return results;
        }

        public async Task CreateEnrollemnt(Enrollment enrollment)
        {
            if (enrollment == null) throw new ArgumentNullException(nameof(enrollment));
            _db.Enrollments.Add(enrollment);
            await _db.SaveChangesAsync();
        }
    }
}