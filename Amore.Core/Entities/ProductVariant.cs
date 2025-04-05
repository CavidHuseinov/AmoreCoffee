using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.Core.Entities
{
    public class ProductVariant
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid VariantId { get; set; }
        public Variant Variant { get; set; }
    }
}
