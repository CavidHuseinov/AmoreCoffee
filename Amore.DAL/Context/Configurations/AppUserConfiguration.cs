using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Amore.Core.Entities;

namespace Amore.DAL.Context.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50); 

            builder.Property(x => x.SurName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Gender)
                .IsRequired();

            builder.Property(x => x.DateOfBirth)
                .IsRequired();

            builder.Property(x => x.UserName)
                .IsRequired();
            builder.HasMany(u => u.Reviews)
                .WithOne(r => r.AppUser)
                .HasForeignKey(r => r.AppUserName) 
                .HasPrincipalKey(u => u.UserName) 
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Checkouts)
                .WithOne(x => x.AppUser)
                .HasForeignKey(x => x.AppUserId);
        }
    }
}
