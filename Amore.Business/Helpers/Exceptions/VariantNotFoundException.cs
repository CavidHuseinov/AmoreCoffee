using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class VariantNotFoundException : Exception
    {
        public VariantNotFoundException(string? message="Variantlar tapilmadi") : base(message)
        {
        }
    }
}
