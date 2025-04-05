using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.DTOs.Payment
{
    public class PaymentRequestDto
    {
        public decimal Amount { get; set; } 
        public string Token { get; set; } 
        public Guid OrderId { get; set; } 
    }
}

