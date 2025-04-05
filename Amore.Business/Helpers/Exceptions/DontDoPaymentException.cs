using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class DontDoPaymentException : Exception
    {
        public DontDoPaymentException(string? message="Ödəmə etmək mümkün olmadı") : base(message)
        {
        }
    }
}
