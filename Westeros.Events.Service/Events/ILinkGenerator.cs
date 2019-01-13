namespace Westeros.Events.Web.Services.Events
{
    public interface ILinkGenerator
    {
        string GenerateRecipeLink(int RecipeId);
    }
}