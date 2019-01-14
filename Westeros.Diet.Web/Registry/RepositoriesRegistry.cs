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
                .AddTransient<IGenericRepository<EntryIngredient>, GenericRepository<EntryIngredient>>()
                .AddTransient<IGenericRepository<EntryRecipe>, GenericRepository<EntryRecipe>>()
                .AddTransient<IGenericRepository<Recipe>, GenericRepository<Recipe>>()
                .AddTransient<IGenericRepository<RecipeDevice>, GenericRepository<RecipeDevice>>()
                .AddTransient<IGenericRepository<RecipeIngredient>, GenericRepository<RecipeIngredient>>()
                .AddTransient<IGenericRepository<DietPlan>, GenericRepository<DietPlan>>()
                .AddTransient<IGenericRepository<UserProfile>, GenericRepository<UserProfile>>()
                .AddTransient<IGenericRepository<Ingredient>, GenericRepository<Ingredient>>()
                .AddTransient<IGenericRepository<Device>, GenericRepository<Device>>();
        }
    }
}
