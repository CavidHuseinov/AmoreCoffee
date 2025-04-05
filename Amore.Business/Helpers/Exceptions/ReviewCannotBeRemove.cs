using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class ReviewCannotBeRemove : Exception
    {
        public ReviewCannotBeRemove():base("Rəyi silmək olmur")
        {
        }

        public ReviewCannotBeRemove(string? message) : base(message)
        {
        }
    }
}
