using System;
using CalorieContent.lib.KeyValueStorage;
using CalorieContent.Repositories.Ingredient;
using CalorieContent.Repositories.Recipe;
using CalorieContent.Services.Ingredient;
using CalorieContent.Services.Recipe;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Storage();

            var recipeRepo = new RecipeRepo(s);
            var ingredientRepo = new IngredientRepo(s);

           var ingredientService = new IngredientService(ingredientRepo);
           var recipeService = new RecipeService(recipeRepo, ingredientRepo);

           var menu = new Menu(recipeService, ingredientService);
           menu.Handle();
        }
    }
}