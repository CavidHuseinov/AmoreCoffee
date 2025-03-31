using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class LocationCannotBeCreated : Exception
    {
        public LocationCannotBeCreated():base("Lokasiya yaratmaq olmur")
        {
        }

        public LocationCannotBeCreated(string? message) : base(message)
        {
        }
    }
}
