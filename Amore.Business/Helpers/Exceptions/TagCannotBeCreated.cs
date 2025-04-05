using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class TagCannotBeCreated : Exception
    {
        public TagCannotBeCreated():base("Teqi yaratmaq mümkün olmadı")
        {
        }

        public TagCannotBeCreated(string? message) : base(message)
        {
        }
    }
}
