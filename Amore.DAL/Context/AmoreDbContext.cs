using Amore.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Amore.DAL.Context
{
    public class AmoreDbContext : IdentityDbContext<AppUser>
    {
        public AmoreDbContext(DbContextOptions<AmoreDbContext> options) : base(options)
        {
        }
        public DbSet<HeadBanner> HeadBanners { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Slogan> Slogans { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTag { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<ShippingInfo> ShippingInfos { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<UserPromocode> UserPromocodes { get; set; }
        public DbSet<Promocode> Promocodes { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<SpotifyPlaylist> SpotifyPlaylists { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
