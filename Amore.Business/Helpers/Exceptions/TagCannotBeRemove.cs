using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class TagCannotBeRemove : Exception
    {
        public TagCannotBeRemove():base("Teqi silmək mümkün olmadı")
        {
        }

        public TagCannotBeRemove(string? message) : base(message)
        {
        }
    }
}
