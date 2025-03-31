using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class ContactFormNotFoundException : Exception
    {
        public ContactFormNotFoundException(string? message="Mesaj göndərilə bilmədi yenidən yoxlayın zəhmət olmasa") : base(message)
        {
        }
    }
}
