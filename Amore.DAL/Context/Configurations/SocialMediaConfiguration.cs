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
    public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.Property(x => x.FacebookUrl)
                .HasMaxLength(255);
            builder.Property(x=>x.LinkedinUrl)
                .HasMaxLength(255);
            builder.Property(x=>x.InstagramUrl)
                .HasMaxLength(255);
            builder.Property(x => x.TwitterUrl)
                .HasMaxLength(255);
        }
    }
}
