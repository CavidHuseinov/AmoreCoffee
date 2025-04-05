using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class ResetPasswordNotFoundException : Exception
    {
        public ResetPasswordNotFoundException():base("Şifrəni sıfırlamaq mümkün olmadı")
        {
        }

        public ResetPasswordNotFoundException(string? message) : base(message)
        {
        }
    }
}
