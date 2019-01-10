using System;
using System.Collections.Generic;
using System.Text;
using Westeros.Diet.Data.Model;

namespace Westeros.Diet.Data.Model
{
    public class RecipeDevice
    {
        public int Id { get; set; }
        //public int RecipeId { get; set; }
        //public int DeviceId { get; set; }
        public Recipe Recipe { get; set; }
        public Device Device { get; set; }
    }
}
