using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class CategoryCannotBeRemove : Exception
    {
        public CategoryCannotBeRemove():base("Kateqoriyanı silmək olmur.")
        {
        }

        public CategoryCannotBeRemove(string? message) : base(message)
        {
        }
    }
}
