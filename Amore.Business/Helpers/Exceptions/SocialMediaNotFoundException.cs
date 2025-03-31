using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class SocialMediaNotFoundException : Exception
    {
        public SocialMediaNotFoundException():base("Sosial Media melumatlarini tapilmir")
        {
        }

        public SocialMediaNotFoundException(string? message) : base(message)
        {
        }
    }
}
