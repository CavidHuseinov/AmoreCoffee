using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class SliderCannotBeRemove : Exception
    {
        public SliderCannotBeRemove():base("Slayder hissənini silmək olmur")
        {
        }

        public SliderCannotBeRemove(string? message) : base(message)
        {
        }
    }
}
