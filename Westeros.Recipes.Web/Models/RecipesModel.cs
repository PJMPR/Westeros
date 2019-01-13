using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Westeros.Recipes.Data.Model;

namespace Westeros.Recipes.Web.Models
{
    public class RecipesModel
    { 
  
        public List<RecipeDevice> RecipeDevices = new List<RecipeDevice>();
        public List<RecipeIngredient> RecipeIngredients = new List<RecipeIngredient>();
        public int Id { get; set; }
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
        public string Description { get; set; }
        public int PrepTime { get; set; }
        public DifficultyType Difficulty { get; set; }
        public string PhotoPath { get; set; }
    }
}
