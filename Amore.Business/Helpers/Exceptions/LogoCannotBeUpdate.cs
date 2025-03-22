using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class LogoCannotBeUpdate : Exception
    {
        public LogoCannotBeUpdate():base("Logo Yeniləmək olmur.")
        {
        }

        public LogoCannotBeUpdate(string? message) : base(message)
        {
        }
    }
}
