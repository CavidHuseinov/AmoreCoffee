using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class ContactCannotBeUpdate : Exception
    {
        public ContactCannotBeUpdate():base("Əlaqə hissəini yeniləmək mümkün olmadı.")
        {
        }

        public ContactCannotBeUpdate(string? message) : base(message)
        {
        }
    }
}
