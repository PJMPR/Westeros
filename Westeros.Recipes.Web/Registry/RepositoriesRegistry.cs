using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Westeros.Recipes.Data.Model;
using Westeros.Recipes.Data.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoriesRegistry
    {

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddTransient<IGenericRepository<Recipe>, GenericRepository<Recipe>>()
                .AddTransient<IGenericRepository<Device>, GenericRepository<Device>>()
                .AddTransient<IGenericRepository<Ingredient>, GenericRepository<Ingredient>>()
                .AddTransient<IGenericRepository<RecipeDevice>, GenericRepository<RecipeDevice>>()
                .AddTransient<IGenericRepository<RecipeIngredient>, GenericRepository<RecipeIngredient>>();
        }
    }
}
