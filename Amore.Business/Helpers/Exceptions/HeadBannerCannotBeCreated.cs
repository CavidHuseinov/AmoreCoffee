using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class HeadBannerCannotBeCreated : Exception
    {
        public HeadBannerCannotBeCreated():base("Başlıq üçün olan banneri yaratmaq olmur.")
        {
        }

        public HeadBannerCannotBeCreated(string? message) : base(message)
        {
        }
    }
}
