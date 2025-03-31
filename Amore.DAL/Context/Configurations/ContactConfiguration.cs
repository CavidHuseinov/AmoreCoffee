﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Amore.DAL.Context.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("DATEADD(HOUR, 4, GETUTCDATE())")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(x => x.Email)
                .IsRequired();
            builder.Property(x=>x.Comment)
                .IsRequired()
                .HasMaxLength(300);

                
        }
    }
}
