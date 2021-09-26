using System;

namespace CalorieContent.Domain.Entities
{
    public class Recipe
    {
        public RecipeIngredient[] Ingredients;

        public Recipe()
        {
            Name = "";
            Ingredients = null;
        }

        public Recipe(string name, RecipeIngredient[] ingredients)
        {
            Name = name;
            Ingredients = (RecipeIngredient[]) ingredients.Clone();
        }

        public string Name { get; set; }
    }

    public class RecipeIngredient
    {
        private double _grams;

        public RecipeIngredient(string name, double grams)
        {
            Name = name;
            Grams = grams;
        }

        public string Name { get; set; }

        public double Grams
        {
            get => _grams;
            set
            {
                if (value <= 0) throw new Exception("wrong value in setter of RecipeIngredient.Grams");

                _grams = value;
            }
        }
    }
}