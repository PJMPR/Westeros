
using Microsoft.Extensions.Configuration;
using Westeros.Demo.ApiClient;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DemoApiRegistry
    {
        public static IServiceCollection AddDemoClient(this IServiceCollection services, IConfiguration config)
        {
            
            return services.AddTransient<IDemoApiClient>(s=>new DemoApiClient(config.GetSection("DemoApi").Value));
        }
    }
}
