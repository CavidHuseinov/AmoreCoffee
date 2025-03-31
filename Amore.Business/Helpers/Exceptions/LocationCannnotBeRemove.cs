using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class LocationCannnotBeRemove : Exception
    {
        public LocationCannnotBeRemove():base("Lokasiyanı silmək olmur")
        {
        }

        public LocationCannnotBeRemove(string? message) : base(message)
        {
        }
    }
}
