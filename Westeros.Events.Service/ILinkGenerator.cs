namespace Westeros.Events.Service
{
    public interface ILinkGenerator
    {
        string GenerateRecipeLink(int RecipeId);
    }
}