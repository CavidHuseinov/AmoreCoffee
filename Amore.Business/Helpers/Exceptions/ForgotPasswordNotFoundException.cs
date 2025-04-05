using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class ForgotPasswordNotFoundException : Exception
    {
        public ForgotPasswordNotFoundException():base("Şifrəni sıfırlamaq mümkün olmadı doğru məlumatları daxil edin.")
        {
        }

        public ForgotPasswordNotFoundException(string? message) : base(message)
        {
        }
    }
}
