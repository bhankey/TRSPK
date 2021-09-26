using System.Collections.Generic;
using System.Linq;
using CalorieContent.Core.Repositories;
using CalorieContent.Services.Recipe.Models;

namespace CalorieContent.Services.Recipe
{
    public class RecipeService : IRecipeService
    {
        private readonly IIngredientRepo _ingredientRepo;
        private readonly IRecipeRepo _recipeRepo;

        public RecipeService(IRecipeRepo recipeRepo, IIngredientRepo ingredientRepo)
        {
            _recipeRepo = recipeRepo;
            _ingredientRepo = ingredientRepo;
        }

        public Domain.Entities.Recipe GetItem(string item)
        {
            return _recipeRepo.Get(item);
        }

        public Dictionary<string, Domain.Entities.Recipe> GetAll()
        {
            return _recipeRepo.GetAll();
        }

        public void Set(Domain.Entities.Recipe entity)
        {
            _recipeRepo.Set(entity);
        }

        public bool Delete(string name)
        {
            return _recipeRepo.Delete(name);
        }

        public RecipeDetailDTO DescribeRecipe(string name)
        {
            var recipe = _recipeRepo.Get(name);

            var allIngredients = _ingredientRepo.GetAll();

            var result = new RecipeDetailDTO();

            result.RecipeName = name;
            foreach (var ingredient in recipe.Ingredients)
            {
                var recipeIngredient = allIngredients[ingredient.Name];

                result.IngredientCalorie.Add(
                    recipeIngredient.Name,
                    recipeIngredient.CalorieContentPerHundredGrams / 100 * ingredient.Grams);
            }

            return result;
        }

        public List<Domain.Entities.Recipe> GetLessSumCalorie(double sumCalorie)
        {
            var recipes = _recipeRepo.GetAll();

            var resultingRecipes = new List<Domain.Entities.Recipe>();
            foreach (var recipe in recipes)
            {
                var description = DescribeRecipe(recipe.Key);

                if (description.SummaryCalories <= sumCalorie) resultingRecipes.Add(recipe.Value);
            }

            return resultingRecipes;
        }

        public List<RecipeDetailDTO> GetRecipesByIngredients(List<string> ingredients)
        {
            var allRecipes = _recipeRepo.GetAll();

            var recipesByIngredients = new Dictionary<string, Domain.Entities.Recipe>();

            foreach (var (recipeName, recipe) in allRecipes)
            {
                var recipeIngredients = new List<string>();

                foreach (var recipeIngredient in recipe.Ingredients) recipeIngredients.Add(recipeIngredient.Name);

                if (recipeIngredients.Intersect(ingredients).Count() >= ingredients.Count)
                    recipesByIngredients.Add(recipeName, recipe);
            }

            var result = new List<RecipeDetailDTO>(recipesByIngredients.Count);
            foreach (var recipe in recipesByIngredients) result.Add(DescribeRecipe(recipe.Key));

            return result;
        }
    }
}