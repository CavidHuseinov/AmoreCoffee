using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.DTOs.ProductTag
{
    public record CreateProductTag
    {
        public Guid ProductId { get; set; }
        public Guid TagId { get; set; }
    }
}
