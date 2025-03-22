using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class LogoCannotBeRemove : Exception
    {
        public LogoCannotBeRemove():base("Logonu silmək olmur.")
        {
        }

        public LogoCannotBeRemove(string? message) : base(message)
        {
        }
    }
}
