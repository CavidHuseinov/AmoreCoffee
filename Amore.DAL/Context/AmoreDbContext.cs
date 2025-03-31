using Amore.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.DAL.Context
{
    public class AmoreDbContext : DbContext
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

    }
}
