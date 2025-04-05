using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class VariantCannotBeCreate : Exception
    {
        public VariantCannotBeCreate(string? message="Variant yaratmaq mumkun olmadi") : base(message)
        {
            
        }
    }
}
