using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class TagNotFoundException : Exception
    {
        public TagNotFoundException():base("Teqlər tapılmadı")
        {
        }

        public TagNotFoundException(string? message) : base(message)
        {
        }
    }
}
