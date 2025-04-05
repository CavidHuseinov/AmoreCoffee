using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class ReviewNotFoundException : Exception
    {
        public ReviewNotFoundException():base("Rəy hissəsi tapılmır")
        {
        }

        public ReviewNotFoundException(string? message) : base(message)
        {
        }
    }
}
