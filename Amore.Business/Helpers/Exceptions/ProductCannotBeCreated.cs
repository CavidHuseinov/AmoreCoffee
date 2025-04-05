using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class ProductCannotBeCreated : Exception
    {
        public ProductCannotBeCreated():base("Yeni məhsul yaratmaq olmur")
        {
        }

        public ProductCannotBeCreated(string? message) : base(message)
        {
        }
    }
}
