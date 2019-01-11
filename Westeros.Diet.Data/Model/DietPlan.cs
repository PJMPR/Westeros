namespace Westeros.Diet.Data.Model
{
    public class DietPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public decimal Proteins { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fats { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}