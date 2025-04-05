
using System;
using Amore.Core.Entities;

namespace Amore.Business.Helpers.DTOs.Checkout
{
    public class GetCheckoutDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; } 
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public string CardholderName { get; set; }
        public string TransactionId { get; set; } 
        public DateTime CreatedAt { get; set; }     


    }
}

