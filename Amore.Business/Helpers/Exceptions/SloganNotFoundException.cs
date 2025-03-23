using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class SloganNotFoundException : Exception
    {
        public SloganNotFoundException():base("Slogan tapilmir")
        {
        }

        public SloganNotFoundException(string? message) : base(message)
        {
        }
    }
}
