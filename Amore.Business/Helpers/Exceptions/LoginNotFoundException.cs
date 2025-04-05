using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class LoginNotFoundException : Exception
    {
        public LoginNotFoundException(string? message="Giris etmek olmur") : base(message)
        {
        }
    }
}
