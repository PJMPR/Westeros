using System.Collections.Generic;
using Westeros.Demo.ApiClient.Contracts;

namespace Westeros.Demo.ApiClient
{
    public interface IRecipesApiClient
    {
        void AddRecipe(RecipesDto Recipe);
        IEnumerable<RecipesDto> AllRecipes();
        void DeleteRecipe(int id);
        RecipesDto GetRecipe(int id);
        void UpdateRecipe(RecipesDto Recipe);


        void AddIngridient(IngridientsDto Ingridient);
        IEnumerable<IngridientsDto> AllIngridients();
        void DeleteIngridient(int id);
        IngridientsDto GetIngridient(int id);
        void UpdateIngridient(IngridientsDto Ingridient);

    }
}