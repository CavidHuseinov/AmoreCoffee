using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class SocialMediaCannotBeUpdate : Exception
    {
        public SocialMediaCannotBeUpdate():base("Sosial media melumatlarini yenilemek olmur")
        {
        }

        public SocialMediaCannotBeUpdate(string? message) : base(message)
        {
        }
    }
}
