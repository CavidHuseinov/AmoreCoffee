using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class LogoCannotBeCreated : Exception
    {
        public LogoCannotBeCreated():base("Logonu yaratmaq olmur ")
        {
        }

        public LogoCannotBeCreated(string? message) : base(message)
        {
        }
    }
}
