using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Westeros.Events.Data.Repositories;

namespace Westeros.Events.Data.Registry
{
    public static class Context
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration config)
        {
            var connection = config.GetConnectionString("demo");
            return services.AddDbContext<EventContext>(options => options.UseSqlServer(connection)); 
        }
    }
}
