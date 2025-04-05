using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;
using Amore.Business.Helpers.DTOs.Tag;

namespace Amore.Business.Helpers.DTOs.ProductTag
{
    public record GetProductTag
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public GetTagDto? Tag { get; set; }

    }
}
