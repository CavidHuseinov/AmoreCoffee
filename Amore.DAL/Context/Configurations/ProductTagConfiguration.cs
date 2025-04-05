using Amore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TagProductConfiguration : IEntityTypeConfiguration<ProductTag>
{
    public void Configure(EntityTypeBuilder<ProductTag> builder)
    {
        builder.HasKey(pt=> pt.Id);

        builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

        builder.HasOne(pt => pt.Product)
               .WithMany(p=> p.Tags)
               .HasForeignKey(pt => pt.ProductId);

        builder.HasOne(pt => pt.Tag)
               .WithMany(t=> t.Products)
               .HasForeignKey(pt => pt.TagId);




    }
}
