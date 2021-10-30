using System.Collections.Generic;
using CalorieContent.Services.Base;
using CalorieContent.Services.Recipe.Models;

namespace CalorieContent.Services.Recipe
{
    public interface IRecipeService : IService<Domain.Entities.Recipe>
    {
        public RecipeDetailDTO DescribeRecipe(string name);
        public List<Domain.Entities.Recipe> GetLessSumCalorie(double sumCalorie);
        public List<RecipeDetailDTO> GetRecipesByIngredients(List<string> ingredients);
    }
}