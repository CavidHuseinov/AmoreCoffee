using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class HeadBannerCannotBeUpdate : Exception
    {
        public HeadBannerCannotBeUpdate():base("Başlıq üçün banneri yeniləmək olmur.")
        {
        }

        public HeadBannerCannotBeUpdate(string? message) : base(message)
        {
        }
    }
}
