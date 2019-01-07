
using Microsoft.Extensions.Configuration;
using Westeros.Demo.ApiClient;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RecipesApiRegistry
    {
        public static IServiceCollection AddDemoClient(this IServiceCollection services, IConfiguration config)
        {
            
            return services.AddTransient<IRecipesApiClient>(s=>new RecipesApiClient(config.GetSection("Recipes").Value));
        }
    }
}
