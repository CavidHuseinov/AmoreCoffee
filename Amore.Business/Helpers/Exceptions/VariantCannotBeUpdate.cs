using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class VariantCannotBeUpdate : Exception
    {
        public VariantCannotBeUpdate(string? message="Varianti yenilemek mumkun olmadi") : base(message)
        {
        }
    }
}
