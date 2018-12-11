using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Westeros.Events.Data.Events;

public static class Extensions
{
    public static IHostBuilder UseHostedService<EventChecker>(this IHostBuilder hostBuilder)
        where EventChecker : class, IHostedService, IDisposable
    {
        return hostBuilder.ConfigureServices(services =>
            services.AddHostedService<EventChecker>());
    }
}