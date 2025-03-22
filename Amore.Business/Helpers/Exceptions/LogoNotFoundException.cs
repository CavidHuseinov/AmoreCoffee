using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class LogoNotFoundException : Exception
    {
        public LogoNotFoundException():base("Logo tapilmadi")
        {
        }

        public LogoNotFoundException(string? message) : base(message)
        {
        }
    }
}
