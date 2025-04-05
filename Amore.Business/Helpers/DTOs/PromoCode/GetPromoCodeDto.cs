using Amore.Business.Helpers.DTOs.UserPromocode;
using Amore.Core.Entities.Common;

namespace Amore.Business.Helpers.DTOs.Promocode
{
    public record GetPromocodeDto
    {
        public Guid Id { get; set; }    
        public string Code { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public string AppUserName { get; set; }
    }
}
