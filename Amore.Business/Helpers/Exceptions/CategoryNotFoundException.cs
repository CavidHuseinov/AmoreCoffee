using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException():base("Kateqoriyalar tapilmir.")
        {
        }

        public CategoryNotFoundException(string? message) : base(message)
        {
        }
    }
}
