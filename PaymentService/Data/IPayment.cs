using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentService.Models;

namespace PaymentService.Data
{
    public interface IPayment
    {
        Task<Enrollment> GetById(int id);
        Task CreateEnrollemnt(Enrollment enrollment);
        Task<IEnumerable<Student>> GetTagihan(string name);
    }
}