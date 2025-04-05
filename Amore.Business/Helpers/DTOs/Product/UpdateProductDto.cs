using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Business.Helpers.DTOs.Common;

namespace Amore.Business.Helpers.DTOs.Product
{
    public record UpdateProductDto:BaseDto
    {
        public string? ImgUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public Guid CategoryId { get; set; }
        public ICollection<Guid> TagIds { get; set; }
        public decimal? FinalPrice
        {
            get
            {
                if (Discount.HasValue)
                    return Price - (Price * Discount.Value / 100);
                return Price;
            }

        }
        public ICollection<Guid> OrderIds { get; set; }
        public ICollection<Guid>? VariantIds { get; set; }

    }
}
