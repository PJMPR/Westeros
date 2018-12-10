using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Events.Data.Model
{
    public class Recipe
    {
        public int Id { get; private set; }
        public Boolean IsNew { get; set; } = true;
        public string Tag { get; set; }
    }
}
