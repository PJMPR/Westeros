
using Westeros.Demo.Data.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WesterosDemoDataRegistry
    {
        public static IServiceCollection AddDemo(this IServiceCollection services)
        {
            return services.AddTransient<ICalculator, Calculator>();
        }
    }
}
