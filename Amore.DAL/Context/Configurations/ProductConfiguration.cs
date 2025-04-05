using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Amore.DAL.Context.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("DATEADD(HOUR, 4, GETUTCDATE())")
                .ValueGeneratedOnAdd();


            builder.Property(x => x.ImgUrl)
                .HasMaxLength(255);
            builder.Property(x => x.Title)
                .IsRequired();
            builder.Property(x=>x.Description)
                .IsRequired();
            builder.Property(x=>x.Price)
                .IsRequired();
            builder.Property(x => x.Discount)
                .HasDefaultValue(0);
            builder.Ignore(x => x.FinalPrice);



            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);


            builder.HasMany(x=>x.Reviews)
                .WithOne(x=>x.Product)
                .HasForeignKey(x=>x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
