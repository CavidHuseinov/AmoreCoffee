using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class SocialMediaCannotBeRemove : Exception
    {
        public SocialMediaCannotBeRemove():base("Sosial Media melumatlarini silmek olmur")
        {
        }

        public SocialMediaCannotBeRemove(string? message) : base(message)
        {
        }
    }
}
