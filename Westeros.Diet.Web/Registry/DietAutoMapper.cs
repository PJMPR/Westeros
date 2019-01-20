using AutoMapper;
using Westeros.Diet.ApiClient.Contracts;
using Westeros.Diet.Data;
using Westeros.Diet.Data.Model;


namespace Westeros.Diet.Web.Registry
{
    public class DietAutoMapper:Profile
    {
        public DietAutoMapper()
        {
            CreateMap<UserProfile, UserProfileDto>();
            CreateMap<Entry, EntryDto>();
            CreateMap<EntryIngredient, EntryIngredientDto>();
            CreateMap<EntryRecipe, EntryRecipeDto>();
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<Recipe, RecipeDto>();
            CreateMap<RecipeIngredient, RecipeIngredientDto>();
            CreateMap<RecipeDevice, RecipeDeviceDto>();
            CreateMap<DietPlan, DietPlanDto>();
            CreateMap<Device, DeviceDto>();
        }
    }
}
