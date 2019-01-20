using System;
using System.Collections.Generic;

namespace Westeros.Diet.ApiClient.Contracts
{
    public class EntryDto { 
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public double Weight { get; set; }
    public ICollection<EntryIngredientDto> EntryIngredients { get; set; } = new List<EntryIngredientDto>();
    public ICollection<EntryRecipeDto> EntryRecipes { get; set; } = new List<EntryRecipeDto>();
    public int UserProfileId { get; set; }
    public UserProfileDto UserProfile { get; set; }

}
}
