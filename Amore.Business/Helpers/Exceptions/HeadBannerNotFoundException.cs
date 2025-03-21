using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class HeadBannerNotFoundException : Exception
    {
        public HeadBannerNotFoundException():base("Başlıq üçün Banner tapılmır.")
        {
        }

        public HeadBannerNotFoundException(string? message) : base(message)
        {
        }
    }
}
