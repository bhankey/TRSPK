using System;

namespace CalorieContent.Services.Ingredient
{
    public class Ingredient
    {
        private double _calorieContentPerHundredGrams;
        
        public string Name { get; set; }

        private double CalorieContentPerHundredGrams
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