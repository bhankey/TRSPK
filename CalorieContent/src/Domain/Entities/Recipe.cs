using System;

namespace CalorieContent.Domain.Entities
{
    public class Recipe
    {
        public string Name { get; set; }
        

        public RecipeIngredient[] Ingredients;

        public Recipe()
        {
            Name = "";
            Ingredients = null;
        }

        public Recipe(string name, RecipeIngredient[] ingredients)
        {
            Name = name;
            Ingredients = (RecipeIngredient[])ingredients.Clone();
        }

    }
    
    public class RecipeIngredient
    {
        public string Name { get; set; }

        private double _grams;
        public double Grams
        {
            get => _grams;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("wrong value in setter of RecipeIngredient.Grams");
                }

                _grams = value;
            }
        }

        public RecipeIngredient(string name, double grams)
        {
            Name = name;
            Grams = grams;
        }
    }
}