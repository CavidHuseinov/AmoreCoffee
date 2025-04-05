using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class PromocodeCannotBeCreated : Exception
    {
        public PromocodeCannotBeCreated(string? message="Promokod yaratmaq mümkün olmadı") : base(message)
        {
        }
    }
}
