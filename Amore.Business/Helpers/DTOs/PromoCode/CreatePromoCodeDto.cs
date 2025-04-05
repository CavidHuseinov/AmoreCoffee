namespace Amore.Business.Helpers.DTOs.Promocode
{
    public record CreatePromocodeDto
    {
        public string Code { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public string AppUserName { get; set; }
    }
}
