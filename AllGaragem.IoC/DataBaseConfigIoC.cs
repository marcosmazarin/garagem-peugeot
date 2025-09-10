using Microsoft.Extensions.DependencyInjection;

namespace AllGaragem.IoC
{
    public static class DataBaseConfigIoC
    {
        public static IServiceCollection AddDataBaseConfig(this IServiceCollection services)
        {
            string? urlSupabase = Environment.GetEnvironmentVariable("SUPABASE_URL")!;
            string? keySupabase = Environment.GetEnvironmentVariable("SUPABASE_KEY")!;

            if (urlSupabase == null || keySupabase == null)
                throw new ArgumentNullException(urlSupabase == null ? nameof(urlSupabase) : nameof(keySupabase));

            services.AddSingleton(provider => new Supabase.Client(urlSupabase, keySupabase));

            return services;
        }
    }
}
