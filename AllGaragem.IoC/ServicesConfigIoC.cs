using AllGaragem.Domain.Interfaces.Services;
using AllGaragem.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGaragem.IoC
{
    public static class ServicesConfigIoC
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMZMSafeLink, MZMSafelink>();

            return services;
        }
    }
}
