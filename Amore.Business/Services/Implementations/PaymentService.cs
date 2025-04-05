using Stripe;
using Amore.Business.Helpers.DTOs.Payment;
using Amore.Business.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Amore.Business.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly string _stripeSecretKey;

        public PaymentService(IConfiguration configuration)
        {
            _stripeSecretKey = configuration["Stripe:Secretkey"];
            StripeConfiguration.ApiKey = _stripeSecretKey;
        }

        public async Task<PaymentResponseDto> ProcessPaymentAsync(PaymentRequestDto request)
        {
            try
            {
                var options = new ChargeCreateOptions
                {
                    Amount = (long)(request.Amount * 100), 
                    Currency = "usd",
                    Source = request.Token, 
                    Description = $"Sifariş üçün ödəniş {request.OrderId}"
                };

                var service = new ChargeService();
                Charge charge = await service.CreateAsync(options);

                if (charge.Status != "succeeded")
                {
                    throw new Exception("Ödəniş olmadı");
                }

                return new PaymentResponseDto
                {
                    IsSuccess = true,
                    TransactionId = charge.Id
                };
            }
            catch (Exception ex)
            {
                return new PaymentResponseDto
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
