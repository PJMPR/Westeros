using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Westeros.Ranking.ApiClient
{
    public static class StarkApiRegistry
    {
        public static IServiceCollection AddStarkApiClient(this IServiceCollection services, IConfiguration config)
        {

            return services.AddTransient<IStarkApiClient>(s => new StarkApiClient(config.GetSection("DemoApi").Value));
        }
    }
}