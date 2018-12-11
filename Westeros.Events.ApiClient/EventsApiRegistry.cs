using Microsoft.Extensions.Configuration;
using Westeros.Events.ApiClient;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class  EventsApiRegistry
    {

        public static IServiceCollection AddEventApiClient(this IServiceCollection services, IConfiguration config)
        {

            return services.AddTransient<IEventsApiClient>(s => new MessageApiClient(config.GetSection("EventApiClient").Value));
        }

    }
}
