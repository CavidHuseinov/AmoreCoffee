using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.Exceptions
{
    public class OrderCannotBeCreate : Exception
    {
        public OrderCannotBeCreate(string? message="Sifariş yaratmaq mümkün olmadı") : base(message)
        {
        }
    }
}
