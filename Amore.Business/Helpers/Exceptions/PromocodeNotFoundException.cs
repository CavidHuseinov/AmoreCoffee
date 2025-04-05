using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class PromocodeNotFoundException : Exception
    {
        public PromocodeNotFoundException(string? message="Promokod tapilmadi") : base(message)
        {
        }
    }
}
