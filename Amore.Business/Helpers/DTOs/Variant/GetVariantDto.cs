using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;
using Amore.Business.Helpers.DTOs.ProductVariant;

namespace Amore.Business.Helpers.DTOs.Variant
{
    public record GetVariantDto:BaseDto
    {
        public string? Name { get; set; }

    }
}
