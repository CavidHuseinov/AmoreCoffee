using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;

namespace Amore.DAL.Context.Configurations
{
    public class ShippingInfoConfiguration : IEntityTypeConfiguration<ShippingInfo>
    {
        public void Configure(EntityTypeBuilder<ShippingInfo> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.StreetAdress).IsRequired();
            builder.Property(x=>x.Apartment).IsRequired();
        }
    }
}
