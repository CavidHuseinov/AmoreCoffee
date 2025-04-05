using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.DTOs.Payment
{
    public class PaymentResponseDto
    {
        public bool IsSuccess { get; set; } 
        public string TransactionId { get; set; }
        public string ErrorMessage { get; set; }
    }
}

