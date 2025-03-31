using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class ContactCannoBeRemove : Exception
    {
        public ContactCannoBeRemove():base("Əlaqə hissəsini silmək olmur.")
        {
        }

        public ContactCannoBeRemove(string? message) : base(message)
        {
        }
    }
}
