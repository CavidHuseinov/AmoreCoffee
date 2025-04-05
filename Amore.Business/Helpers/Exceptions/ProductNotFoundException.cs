using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException():base("Məhsul tapılmır")
        {
        }

        public ProductNotFoundException(string? message) : base(message)
        {
        }
    }
}
