
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Westeros.Events.Data.Model;
using Westeros.Events.Data.Repositories;

namespace Westeros.Events.Data.Registry
{
    public static class RepositoriesRegistry
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddTransient<IGenericRepository<IMessage>, GenericRepository<IMessage>>()
                .AddTransient<IGenericRepository<MailServer>, GenericRepository<MailServer>>()
                .AddTransient<IGenericRepository<Recipe>, GenericRepository<Recipe>>()
                .AddTransient<IGenericRepository<Profile>, GenericRepository<Profile>>()
                .AddTransient<IGenericRepository<LogRecord>, GenericRepository<LogRecord>>();
        }
    }
}