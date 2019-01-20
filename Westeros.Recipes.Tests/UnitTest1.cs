using Microsoft.VisualStudio.TestTools.UnitTesting;
using Westeros.Recipes.Data.Model;

namespace Westeros.Recipes.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Ingredient Makaron = new Ingredient();
            Makaron.Calories = 32;
            Recipe Ramen = new Recipe();
            Ramen.RecipeIngredients.Add();


            Assert.AreEqual(32, Ramen.Calories);

        }
    }
}
