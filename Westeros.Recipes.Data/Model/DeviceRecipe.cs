using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Recipes.Data.Model
{
    public class DeviceRecipe
    {
        public int ID { get; set; }
        public int DeviceID { get; set; }
        public int RecipeID { get; set; }
        public Device Device { get; set;}
        public Recipe Recipe { get; set; }

    }
}
