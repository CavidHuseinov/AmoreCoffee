using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class HeadBannerCannotBeRemove : Exception
    {
        public HeadBannerCannotBeRemove():base("Başlıq üçün olan banneri silmək olmur.")
        {
        }

        public HeadBannerCannotBeRemove(string? message) : base(message)
        {
        }
    }
}
