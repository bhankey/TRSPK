using System;

namespace CalorieContent.Domain.Entities
{
    public class Ingredient
    {
        
        public string Name { get; set; }

        private double _calorieContentPerHundredGrams;
        
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