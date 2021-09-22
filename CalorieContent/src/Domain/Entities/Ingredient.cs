using System;

namespace CalorieContent.Domain.Entities
{
    public class Ingredient
    {
        public Ingredient()
        {
            Name = "";
            _calorieContentPerHundredGrams = 0;
        }
        
        public Ingredient(string name, double calorieContentPerHundredGrams)
        {
            Name = name;
            CalorieContentPerHundredGrams = calorieContentPerHundredGrams;
        }
        
        public Ingredient(Ingredient copy)
        {
            Name = copy.Name;
            _calorieContentPerHundredGrams = copy._calorieContentPerHundredGrams;
        }
        
        
        public string Name { get; set; }

        private double _calorieContentPerHundredGrams;
        
        public double CalorieContentPerHundredGrams
        {
            get => _calorieContentPerHundredGrams;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("wrong value in setter of Ingredient.CalorieContentPerHundredGrams");
                }

                _calorieContentPerHundredGrams = value;
            }
        }
    }
    
}