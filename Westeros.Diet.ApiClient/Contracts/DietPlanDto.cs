using System;
using System.Collections.Generic;
using System.Text;

namespace Westeros.Diet.ApiClient.Contracts
{
    public class DietPlanDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public double Proteins { get; set; }
        public double Carbohydrates { get; set; }
        public double Fats { get; set; }
        public int UserProfileId { get; set; }
        public UserProfileDto UserProfile { get; set; }
    }
}
