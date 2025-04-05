using System;

namespace Amore.Business.Helpers.Exceptions
{
    public class PaymentFailedException : Exception
    {
        public PaymentFailedException() : base("Ödəmə uğursuz oldu") { }

        public PaymentFailedException(string message) : base(message) { }

        public PaymentFailedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
