using Amore.Business.Services.Implementations;
using Amore.Business.Services.Implementations.Amore.Business.Services.Implementations;
using Amore.Business.Services.Interfaces;
using Amore.Service.Services;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Amore.Business
{
    public static class BusinessServiceRegistrations
    {
        public static void AddBusinessService(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IHeadBannerService), typeof(HeadBannerService));
            services.AddScoped(typeof(ILogoService), typeof(LogoService));
            services.AddScoped(typeof(IUploadFileService), typeof(UploadFileService));
            services.AddScoped(typeof(ISliderService), typeof(SliderService));
            services.AddScoped(typeof(ISloganService), typeof(SloganService));
            services.AddScoped(typeof(ILocationService), typeof(LocationService));
            services.AddScoped(typeof(ISocialMediaService), typeof(SocialMediaService));
            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped(typeof(ITagService), typeof(TagService));
            services.AddScoped(typeof(IEmailService), typeof(EmailService));
            services.AddScoped(typeof(INotificationService), typeof(NotificationService));
            services.AddScoped(typeof(IOrderService), typeof(OrderService));
            services.AddScoped(typeof(IReviewService), typeof(ReviewService));
            services.AddScoped(typeof(ICheckoutService), typeof(CheckoutService));
            services.AddScoped(typeof(IShippingInfoService), typeof(ShippingInfoService));
            services.AddScoped(typeof(IPaymentService), typeof(PaymentService));
            services.AddScoped(typeof(IPromocodeService), typeof(PromocodeService));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IVariantService), typeof(VariantService));
            services.AddScoped<ISpotifyService, SpotifyService>();
            services.AddMemoryCache();
        }

        public static async Task SeedDatabaseAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await Business.Helpers.Seeds.DataSeeder.SeedRolesAsync(roleManager);
        }

    }
}
