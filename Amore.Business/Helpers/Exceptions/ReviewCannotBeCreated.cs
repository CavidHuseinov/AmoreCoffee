using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class ReviewCannotBeCreated : Exception
    {
        public ReviewCannotBeCreated():base("Rəy yaratmaq olmur")
        {
        }

        public ReviewCannotBeCreated(string? message) : base(message)
        {
        }
    }
}
