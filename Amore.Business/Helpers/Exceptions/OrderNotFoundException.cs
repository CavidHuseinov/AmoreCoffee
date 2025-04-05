using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(string? message= "Məhsul tapılmır") : base(message)
        {
        }
    }
}
