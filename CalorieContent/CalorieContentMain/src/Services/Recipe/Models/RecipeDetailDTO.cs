using System.Collections.Generic;
using System.Linq;

namespace CalorieContent.Services.Recipe.Models
{
    public class RecipeDetailDTO
    {
        // Dictionary: Name - calorie
        public Dictionary<string, double> IngredientCalorie;
        public string RecipeName;

        public RecipeDetailDTO()
        {
            IngredientCalorie = new Dictionary<string, double>();
        }

        public double SummaryCalories
        {
            get { return IngredientCalorie.Sum(ingredient => ingredient.Value); }
        }
    }
}