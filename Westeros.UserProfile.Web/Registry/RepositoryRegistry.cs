using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Westeros.UserProfile.Data;
using Westeros.UserProfile.Data.Repositories;

namespace Westeros.UserProfile.Web.Registry
{
    public static class RepositoryRegistry
    {
        public static IServiceCollection AddRepositories (this IServiceCollection services)
        {
            return services.AddTransient<IGenericRepository<User>, GenericRepository<User>>();
        }
    }
}
