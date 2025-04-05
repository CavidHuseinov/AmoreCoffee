using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Business.Helpers.DTOs.ProductVariant
{
    public record CreateProductVariant
    {
        public Guid ProductId { get; set; }
        public Guid VariantId { get; set; }
    }
}
