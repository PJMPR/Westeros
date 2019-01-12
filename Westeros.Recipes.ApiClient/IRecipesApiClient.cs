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


        void AddIngredient(IngredientsDto ingredient);
        IEnumerable<IngredientsDto> AllIngredients();
        void DeleteIngredient(int id);
        IngredientsDto GetIngredient(int id);
        void UpdateIngredient(IngredientsDto ingredient);

    }
}