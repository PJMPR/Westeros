namespace Westeros.Diet.Data.Model
{
    public class Diet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; private set; }
        public decimal Proteins { get; private set; }
        public decimal Carbohydrates { get; private set; }
        public decimal Fats { get; private set; }
    }
}