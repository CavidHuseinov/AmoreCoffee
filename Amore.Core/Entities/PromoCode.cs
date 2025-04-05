using System;
using Amore.Core.Entities.Common;

namespace Amore.Core.Entities
{
    public class Promocode : BaseEntity
    {
        public string Code { get; set; }
        public decimal DiscountPercentage { get; set; } 
        public DateTime ExpirationDate { get; set; } 
        public bool IsActive { get; set; }
        public ICollection<UserPromocode>? UserPromocodes { get; set; }

    }
}
