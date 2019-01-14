using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Westeros.Diet.Data.Model
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public double Calories => CaloriesCalc();
        [NotMapped]
        public double Proteins => ProteinsCalc();
        [NotMapped]
        public double Carbohydrates => CarbsCalc();
        [NotMapped]
        public double Fats => FatsCalc();
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public ICollection<EntryIngredient> EntryIngredients { get; set; } = new List<EntryIngredient>();
        public ICollection<EntryRecipe> EntryRecipes { get; set; } = new List<EntryRecipe>();
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        private double CaloriesCalc()
        {
            double sumCalories = 0;

            foreach (var ing in EntryIngredients)
            {
                sumCalories += ing.Ingredient.Calories;
            }

            foreach (var ing in EntryRecipes)
            {
                sumCalories += ing.Recipe.Calories;
            }


            return sumCalories;
        }

        private double ProteinsCalc()
        {
            double sumProteins = 0;

            foreach (var ing in EntryIngredients)
            {
                sumProteins += ing.Ingredient.Proteins;
            }

            foreach (var ing in EntryRecipes)
            {
                sumProteins += ing.Recipe.Proteins;
            }

            return sumProteins;
        }

        private double CarbsCalc()
        {
            double sumCarbs = 0;

            foreach (var ing in EntryIngredients)
            {
                sumCarbs += ing.Ingredient.Carbohydrates;
            }

            foreach (var ing in EntryRecipes)
            {
                sumCarbs += ing.Recipe.Carbohydrates;
            }

            return sumCarbs;
        }

        private double FatsCalc()
        {
            double sumFats = 0;

            foreach (var ing in EntryIngredients)
            {
                sumFats += ing.Ingredient.Fats;
            }

            foreach (var ing in EntryRecipes)
            {
                sumFats += ing.Recipe.Fats;
            }

            return sumFats;
        }
    }
}