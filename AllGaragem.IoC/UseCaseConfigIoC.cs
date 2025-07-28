using AllGaragem.Application.ProductCheckout.Interfaces.Product.Actions.Create;
using AllGaragem.Application.ProductCheckout.UseCases.Product.Actions.Create;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllGaragem.IoC
{
    public static class UseCaseConfigIoC
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();

            return services;
        }
    }
}
