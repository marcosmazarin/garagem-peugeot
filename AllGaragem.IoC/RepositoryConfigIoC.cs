using AllGaragem.Domain.Interfaces.Persistence;
using AllGaragem.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace AllGaragem.IoC
{
    public static class RepositoryConfigIoC
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
