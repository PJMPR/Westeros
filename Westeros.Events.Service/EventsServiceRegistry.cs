
using Microsoft.Extensions.Configuration;
using Westeros.Events.Service;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EventsServiceRegistry
    {

        public static IServiceCollection AddEventService(this IServiceCollection services, IConfiguration config)
        {

            return services.AddTransient<ILinkGenerator>(s => new LinkGenerator(config.GetSection("RecipeBaseAddress").Value));
        }

    }
}