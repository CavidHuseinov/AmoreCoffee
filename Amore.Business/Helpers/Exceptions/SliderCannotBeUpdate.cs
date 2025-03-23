using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class SliderCannotBeUpdate : Exception
    {
        public SliderCannotBeUpdate():base("Slayder hissəsin yeniləmək olmur")
        {
        }

        public SliderCannotBeUpdate(string? message) : base(message)
        {
        }
    }
}
