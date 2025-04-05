using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class CategoryCannotBeUpdate : Exception
    {
        public CategoryCannotBeUpdate():base("Kateqoriyanı yeniləmək olmur ")
        {
        }

        public CategoryCannotBeUpdate(string? message) : base(message)
        {
        }
    }
}
