using EnrollmentService.Dtos;
using System.Threading.Tasks;

namespace EnrollmentService.SyncHttpDataServices.Http
{
    public interface IPaymentDataClient
    {
        Task CreateEnrollmentFromPaymentService(EnrollmentDto enrollment);
    }
}