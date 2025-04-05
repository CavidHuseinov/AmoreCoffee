using System.Collections.Generic;
using Amore.Core.Entities.Common;

namespace Amore.Core.Entities
{
    public class Product : BaseEntity
    {
        public string? ImgUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<ProductTag>? Tags { get; set; }
        public decimal? FinalPrice
        {
            get
            {
                if (Discount.HasValue)
                    return Price - (Price * Discount.Value / 100);
                return Price;
            }
        }

        public ICollection<Review>? Reviews { get; set; }

        public ICollection<OrderProduct>? OrderProducts { get; set; }
        public ICollection<ProductVariant>? ProductVariants { get; set; }
    }
}
