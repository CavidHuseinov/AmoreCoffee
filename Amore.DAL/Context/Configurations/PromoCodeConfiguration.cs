using Amore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Amore.DAL.Context.Configurations
{
    public class PromocodeConfiguration : IEntityTypeConfiguration<Promocode>
    {
        public void Configure(EntityTypeBuilder<Promocode> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.DiscountPercentage)
                .IsRequired();

            builder.Property(p => p.ExpirationDate)
                .IsRequired();

            builder.Property(p => p.IsActive)
                .HasDefaultValue(true); 
        }
    }
}
