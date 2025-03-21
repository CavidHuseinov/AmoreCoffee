using Amore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.DAL.Context.Configurations
{
    public class HeadBannerConfiguration : IEntityTypeConfiguration<HeadBanner>
    {
        public void Configure(EntityTypeBuilder<HeadBanner> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("DATEADD(HOUR, 4, GETUTCDATE())")
                .ValueGeneratedOnAdd();


            builder.Property(x => x.Description)
                .IsRequired();
        }
    }
}
