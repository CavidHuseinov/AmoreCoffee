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
    public class UserPromocodeConfiguration : IEntityTypeConfiguration<UserPromocode>
    {
        public void Configure(EntityTypeBuilder<UserPromocode> builder)
        {
            builder.HasKey(x => new { x.PromocodeId,x.AppUserId});

            builder.HasOne(x => x.Promocode)
                .WithMany(x => x.UserPromocodes)
                .HasForeignKey(x => x.PromocodeId);

            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.UserPromocodes)
                .HasForeignKey(x => x.AppUserId);

        }
    }
}
