namespace Westeros.Diet.Data.Model
{
    public class DietPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public double Proteins { get; set; }
        public double Carbohydrates { get; set; }
        public double Fats { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}