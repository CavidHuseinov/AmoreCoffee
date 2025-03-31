using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class LocationCannotBeUpdate : Exception
    {
        public LocationCannotBeUpdate():base("Lokasiyanı yeniləmək olmur.")
        {
        }

        public LocationCannotBeUpdate(string? message) : base(message)
        {
        }
    }
}
