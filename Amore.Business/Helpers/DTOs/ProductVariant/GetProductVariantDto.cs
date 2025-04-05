using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;
using Amore.Business.Helpers.DTOs.Variant;

namespace Amore.Business.Helpers.DTOs.ProductVariant
{
    public record GetProductVariantDto
    {
        public Guid VariantId { get; set; }
        public Guid ProductId { get; set; }
        public GetVariantDto? Variant { get; set; }
    }
}
