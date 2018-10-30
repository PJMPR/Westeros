using System.Collections.Generic;

namespace Westeros.Diet.Data
{
    public interface IIngredient
    {
        int Calories { get; }
        double Carbs { get; }
        double Fats { get; }
        int Id { get; }
        string Image { get; }
        string Name { get; }
        double Proteins { get; }
        List<string> GetAllTags();
    }
}