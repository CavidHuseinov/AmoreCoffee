using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class SloganCannotBeUpdate : Exception
    {
        public SloganCannotBeUpdate():base("Slogan yeniləmək olmur.")
        {
        }

        public SloganCannotBeUpdate(string? message) : base(message)
        {
        }
    }
}
