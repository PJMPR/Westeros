using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Westeros.Diet.Data;
using Westeros.Diet.Data.Model;

namespace Westeros.Diet.Web.Models
{
    public class EntriesCreateModel
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }

        private DateTime? dateCreated = null;

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [RegularExpression("([0-9]+)")]
        public double Weight { get; set; }
        public int UserProfileId { get; set; }
        public List<EntryIngredient> EntryIngredients { get; set; } = new List<EntryIngredient>();
        public List<EntryRecipe> EntryRecipes { get; set; } = new List<EntryRecipe>();
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
