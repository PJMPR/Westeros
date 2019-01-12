using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Westeros.Diet.Data;
using Westeros.Diet.Data.Model;
using Westeros.Diet.Data.Repositories;

namespace Westeros.Diet.Web.Registry
{
    public static class RepositoriesRegistry
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddTransient<IGenericRepository<Entry>, GenericRepository<Entry>>()
                .AddTransient<IGenericRepository<IngredientEntry>, GenericRepository<IngredientEntry>>()
                .AddTransient<IGenericRepository<RecipeEntry>, GenericRepository<RecipeEntry>>();
        }
    }
}
