using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class LocationNotFoundException : Exception
    {
        public LocationNotFoundException():base("Lokasiya tapilmir")
        {
        }

        public LocationNotFoundException(string? message) : base(message)
        {
        }
    }
}
