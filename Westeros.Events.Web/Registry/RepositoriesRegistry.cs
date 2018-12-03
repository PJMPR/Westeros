
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Westeros.Events.Data.Model;
using Westeros.Events.Data.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoriesRegistry
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddTransient<IGenericRepository<Message>, GenericRepository<Message>>()
                .AddTransient<IGenericRepository<Profile>, GenericRepository<Profile>>()
                .AddTransient<IGenericRepository<LogRecord>, GenericRepository<LogRecord>>();
        }
    }
}