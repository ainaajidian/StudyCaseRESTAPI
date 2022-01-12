using EnrollmentService.Dtos;
using System.Threading.Tasks;

namespace EnrollmentService.SyncHttpDataServices.Http
{
    public interface IEnrollmentDataClient
    {
        Task CreateEnrollmentFromPaymentService(EnrollmentCreateDto enrollment);
    }
}