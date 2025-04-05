using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amore.Core.Entities;
using Amore.DAL.Repositories.Implementations;
using Amore.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Amore.DAL
{
    public static class DALServiceRegistrations
    {

        public static void AddDALService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IHeadBannerRepository), typeof(HeadBannerRepository));
            services.AddScoped(typeof(ILogoRepository), typeof(LogoRepository));
            services.AddScoped(typeof(ISliderRepository), typeof(SliderRepository));
            services.AddScoped(typeof(ISloganRepository), typeof(SloganRepository));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(ITagRepository), typeof(TagRepository));
            services.AddScoped(typeof(INotificationRepository), typeof(NotificationRepository));
            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));
            services.AddScoped(typeof(ICheckoutRepository), typeof(CheckoutRepository));
            services.AddScoped(typeof(IShippingInfoRepository), typeof(ShippingInfoRepository));
            services.AddScoped(typeof(IPromocodeRepository), typeof(PromocodeRepository));
            services.AddScoped(typeof(IVariantRepository), typeof(VariantRepository));

        }
    }
}
