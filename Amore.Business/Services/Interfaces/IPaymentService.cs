using Amore.Business.Helpers.DTOs.Payment;
using System.Threading.Tasks;

namespace Amore.Business.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> ProcessPaymentAsync(PaymentRequestDto request);
    }
}
