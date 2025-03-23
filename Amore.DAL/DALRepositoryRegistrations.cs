using Amore.DAL.Repositories.Implementations;
using Amore.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amore.DAL
{
    public static class DALRepositoryRegistrations
    {

        public static void AddDALRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IHeadBannerRepository), typeof(HeadBannerRepository));
            services.AddScoped(typeof(ILogoRepository), typeof(LogoRepository));
            services.AddScoped(typeof(ISloganRepository), typeof(SloganRepository));
            services.AddScoped(typeof(ISliderRepository), typeof(SliderRepository));
        }
    }
}