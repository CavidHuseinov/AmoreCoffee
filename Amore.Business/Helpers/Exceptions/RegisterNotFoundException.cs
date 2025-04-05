using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Security;

namespace Amore.Business.Helpers.Exceptions
{
    public class RegisterNotFoundException : Exception
    {

        public RegisterNotFoundException(string? message = "Qeydiyyat etmek olmur") : base(message)
        {
            
        }
    }
}
