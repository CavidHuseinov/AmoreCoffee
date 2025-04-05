using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class VariantCannotBeDelete : Exception
    {
        public VariantCannotBeDelete(string? message="Varianti silmek olmur") : base(message)
        {
        }
    }
}
