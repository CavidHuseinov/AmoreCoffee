using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class ContactCannotBeCreated : Exception
    {
        public ContactCannotBeCreated():base("Əlaqə hissəsini yaratmaq olmur")
        {
        }

        public ContactCannotBeCreated(string? message) : base(message)
        {
        }
    }
}
