using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class SliderNotFoundException : Exception
    {
        public SliderNotFoundException():base("Slayder Hissəsi tapılmır")
        {
        }

        public SliderNotFoundException(string? message) : base(message)
        {
        }
    }
}
