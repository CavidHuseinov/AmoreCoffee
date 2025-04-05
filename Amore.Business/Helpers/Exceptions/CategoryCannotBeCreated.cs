using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class CategoryCannotBeCreated : Exception
    {
        public CategoryCannotBeCreated():base("Kateqoriya yaratmaq olmur")
        {
        }

        public CategoryCannotBeCreated(string? message) : base(message)
        {
        }
    }
}
