using System;
using Amore.Core.Entities.Common;

namespace Amore.Core.Entities
{
    public class Checkout : BaseEntity
    {
        public Guid OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public string CardholderName { get; set; }
        public string TransactionId { get; set; }
        public string CardNumber { get; set; }
        public string EXP { get; set; }
        public string CVV { get; set; }
        public string Promocode { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
