using AllGaragem.Application.ProductCheckout.DTO.Product.Actions.Create;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AllGaragem.IoC
{
    public static class ValidatorsConfigIoC
    {
        public static IServiceCollection AddValidatorsConfigIoC(this IServiceCollection services)
        {            
            services.AddScoped<IValidator<CreateProductRequestDTO>, CreateProductRequestDTOValidator>();

            return services;
        }
    }
}
