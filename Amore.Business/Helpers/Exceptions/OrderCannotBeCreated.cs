using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class OrderCannotBeCreated : Exception
    {
        public OrderCannotBeCreated(string? message="Sifariş etmək mümkün olmadı") : base(message)
        {
        }
    }
}
