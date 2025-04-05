using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class ProductCannotBeUpdate : Exception
    {
        public ProductCannotBeUpdate():base("Məhsulu yeniləmək olmur ")
        {
        }

        public ProductCannotBeUpdate(string? message) : base(message)
        {
        }
    }
}
