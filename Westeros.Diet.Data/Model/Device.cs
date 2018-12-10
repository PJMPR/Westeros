﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Westeros.Diet.Data.Model
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RecipeDevice> RecipeDevices { get; set; }
    }
}
