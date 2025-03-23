using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class SloganCannotBeRemove : Exception
    {
        public SloganCannotBeRemove():base("Sloganı silmək olmur.")
        {
        }

        public SloganCannotBeRemove(string? message) : base(message)
        {
        }
    }
}
