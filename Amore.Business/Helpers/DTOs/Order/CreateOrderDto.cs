using Amore.Core.Enums;

public record CreateOrderDto
{
    public string AppUserId { get; set; }
    public ICollection<Guid> ProductIds { get; set; }
}
