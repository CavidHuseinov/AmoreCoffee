using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class SliderCannotBeCreated : Exception
    {
        public SliderCannotBeCreated():base("Slayderi yaratmaq olmur")
        {
        }

        public SliderCannotBeCreated(string? message) : base(message)
        {
        }
    }
}
