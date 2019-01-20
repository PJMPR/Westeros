using System;
using System.Collections.Generic;
using Westeros.Diet.Data;

namespace Westeros.Diet.ApiClient.Contracts
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Boolean IsNew { get; set; } = true;
        public CuisineType Cuisine { get; set; }
        public string Description { get; set; }
        public int PrepTime { get; set; }
        public DifficultyType Difficulty { get; set; } 
        public string PhotoPath { get; set; }
        public ICollection<RecipeDeviceDto> RecipeDevices { get; set; } = new List<RecipeDeviceDto>();
        public ICollection<RecipeIngredientDto> RecipeIngredients { get; set; } = new List<RecipeIngredientDto>();
    }
}
