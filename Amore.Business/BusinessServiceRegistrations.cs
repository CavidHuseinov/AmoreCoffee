using Amore.Business.Services.Implementations;
using Amore.Business.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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


        }
    }
}
