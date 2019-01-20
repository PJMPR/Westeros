using Microsoft.Extensions.Configuration;
using Westeros.Diet.ApiClient;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DemoApiRegistry
    {
        public static IServiceCollection AddDietClient(this IServiceCollection services, IConfiguration config)
        {

            return services.AddTransient<IDietApiClient>(s => new DietApiClient(config.GetSection("DietApi").Value));
        }
    }
}
