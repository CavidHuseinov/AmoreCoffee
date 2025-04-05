using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class ReviewCannotBeUpdate : Exception
    {
        public ReviewCannotBeUpdate():base("Rəyi yeniləmək olmur")
        {
        }

        public ReviewCannotBeUpdate(string? message) : base(message)
        {
        }
    }
}
