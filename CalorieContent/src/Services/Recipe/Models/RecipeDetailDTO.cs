using System.Collections.Generic;
using System.Linq;

namespace CalorieContent.Services.Recipe.Models
{
    public class RecipeDetailDTO
    {
        public string RecipeName;

        // Dictionary: Name - calorie
        public Dictionary<string, double> IngredientCalorie;

        public double SummaryCalories
        {
            get
            {
                return IngredientCalorie.Sum(ingredient => ingredient.Value);
            }
        }
    }
}