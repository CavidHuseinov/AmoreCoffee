using Amore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Amore.DAL.Context.Configurations
{
    public class CheckoutConfiguration : IEntityTypeConfiguration<Checkout>
    {
        public void Configure(EntityTypeBuilder<Checkout> builder)
        {
            builder.Property(x => x.CardholderName).IsRequired();
            builder.Property(x => x.TransactionId).IsRequired();
            builder.Property(x => x.TotalPrice).IsRequired();

            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.Checkouts)
                .HasForeignKey(x => x.AppUserId);
        }
    }
}
