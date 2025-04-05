using System.Collections.Generic;
using Amore.Business.Helpers.DTOs.Common;
using Amore.Business.Helpers.DTOs.Order;
using Amore.Business.Helpers.DTOs.ProductTag;
using Amore.Business.Helpers.DTOs.ProductVariant;
using Amore.Business.Helpers.DTOs.Tag;  // Order DTO'yu ekledik

namespace Amore.Business.Helpers.DTOs.Product
{
    public record GetProductDto : BaseDto
    {
        public string? ImgUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public ICollection<GetProductTag>? Tags { get; set; }

        public decimal? FinalPrice
        {
            get
            {
                if (Discount.HasValue)
                    return Price - (Price * Discount.Value / 100);
                return Price;
            }
        }
        public ICollection<GetProductVariantDto>? ProductVariants { get; set; }
    }
}
