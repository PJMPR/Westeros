using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Westeros.Recipes.Data.Model
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        ICollection<RecipeDevice> DeviceRecipes { get; set; } = new List<RecipeDevice>();
    }
}
