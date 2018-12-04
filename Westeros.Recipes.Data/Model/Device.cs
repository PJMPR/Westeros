﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Westeros.Recipes.Data.Model
{
    public class Device
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}