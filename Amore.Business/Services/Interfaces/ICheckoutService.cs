using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Checkout;
using Amore.Business.Helpers.DTOs.Payment;

namespace Amore.Business.Services.Interfaces
{
    public interface ICheckoutService
    {
        Task<GetCheckoutDto> ProcessPaymentAsync(CreateCheckoutDto dto);

    }
}
