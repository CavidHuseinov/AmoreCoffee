using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;

namespace Amore.Business.Helpers.DTOs.Variant
{
    public record UpdateVariantDto:BaseDto
    {
        public string Name { get; set; }
        public ICollection<Guid>? VariantIds { get; set; }

    }
}
