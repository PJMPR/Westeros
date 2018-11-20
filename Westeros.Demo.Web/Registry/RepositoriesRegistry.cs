using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Westeros.Demo.Data.Model;
using Westeros.Demo.Data.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoriesRegistry
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddTransient<IGenericRepository<Person>, GenericRepository<Person>>()
                .AddTransient<IGenericRepository<Address>, GenericRepository<Address>>();
        }
    }
}
