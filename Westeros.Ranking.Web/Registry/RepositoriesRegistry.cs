using Microsoft.Extensions.DependencyInjection;
using Westeros.Ranking.Data;
using Westeros.Ranking.Data.Model;
using Westeros.Ranking.Data.Repositories;

namespace Westeros.Ranking.Web.Registry
{
    public static class RepositoriesRegistry
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddTransient<IGenericRepository<Dieta>, GenericRepository<Dieta>>()
                .AddTransient<IGenericRepository<Oceny>, GenericRepository<Oceny>>()
                .AddTransient<IGenericRepository<Przepis>, GenericRepository<Przepis>>();
        }
    }
}