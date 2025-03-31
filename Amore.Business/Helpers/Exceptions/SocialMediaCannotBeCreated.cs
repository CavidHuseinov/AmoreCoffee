using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class SocialMediaCannotBeCreated : Exception
    {
        public SocialMediaCannotBeCreated():base("Sosial media melumatlarini yaratmaq olmur")
        {
        }

        public SocialMediaCannotBeCreated(string? message) : base(message)
        {
        }
    }
}
