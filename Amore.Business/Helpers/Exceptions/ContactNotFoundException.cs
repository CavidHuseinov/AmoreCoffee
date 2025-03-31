using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class ContactNotFoundException : Exception
    {
        public ContactNotFoundException():base("Əlaqə hissəsi boş olmasınm zəhmət olmasa")
        {
        }

        public ContactNotFoundException(string? message) : base(message)
        {
        }
    }
}
