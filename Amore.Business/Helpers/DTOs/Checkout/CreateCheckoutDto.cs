using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.DTOs.Checkout
{
    public record CreateCheckoutDto
    {
        public Guid OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentToken { get; set; }

        public string PaymentMethod { get; set; } = "Visa";
        public string CardholderName { get; set; }
        public string CardNumber { get; set; }
        public string EXP { get; set; }
        public string CVV { get; set; }
        public string? Promocode { get; set; }
        public string AppUserId {  get; set; }
    }
}
