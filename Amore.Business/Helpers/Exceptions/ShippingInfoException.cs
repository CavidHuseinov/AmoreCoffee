using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class ShippingInfoException : Exception
    {
        public ShippingInfoException(string? message="Çatdırılma üçün olan məlumatları yadda saxlamaq mümkün olmadı.") : base(message)
        {
        }
    }
}
