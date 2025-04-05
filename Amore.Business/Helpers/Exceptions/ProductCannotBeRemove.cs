using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class ProductCannotBeRemove : Exception
    {
        public ProductCannotBeRemove():base("Məhsulu silmək olmur")
        {
        }

        public ProductCannotBeRemove(string? message) : base(message)
        {
        }
    }
}
