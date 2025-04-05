using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class TagCannotBeUpdate : Exception
    {
        public TagCannotBeUpdate():base("Teqi yeniləmək mümkün olmadı")
        {
        }

        public TagCannotBeUpdate(string? message) : base(message)
        {
        }
    }
}
