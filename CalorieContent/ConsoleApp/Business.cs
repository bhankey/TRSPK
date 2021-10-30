using System;
using System.Collections.Generic;
using System.Text;
using CalorieContent.Services.Recipe;

namespace ConsoleApp
{
    public class Business
    {
        private readonly IRecipeService RecipeService;

        public Business(IRecipeService recipeService)
        {
            RecipeService = recipeService;
        }

        public string RecipeDetails(string recipeName)
        {
            try
            {
                var recipe = RecipeService.DescribeRecipe(recipeName);

                StringBuilder result = new StringBuilder();

                result.Append("Recipe name: ");
                result.Append(recipe.RecipeName);
                result.Append("\n");

                result.Append("Ingredients: \n");
                foreach (var i in recipe.IngredientCalorie)
                {
                    result.Append("\t");
                    result.Append(i.Key);
                    result.Append(" - ");
                    result.Append(i.Value);
                    result.Append(" calorie\n");
                }

                return result.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string RecipesCalorieLowerThan(int calories)
        {
            try
            {
                var recipes = RecipeService.GetLessSumCalorie(calories);

                var result = new StringBuilder();
                foreach (var recipe in recipes)
                {
                    result.Append("Recipe name: ");
                    result.Append(recipe.Name);
                    result.Append("\n");

                    result.Append("Ingredients: \n");
                    foreach (var ingredient in recipe.Ingredients)
                    {
                        result.Append("\t");
                        result.Append(ingredient.Name);
                        result.Append(" - ");
                        result.Append(ingredient.Grams);
                        result.Append(" grams\n");
                    }
                }

                if (recipes.Count == 0)
                {
                    result.Append("No recipes lower than that calorie: " + calories);
                }

                return result.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string RecipesConsistOf(string ingredients)
        {
            try
            {
                var recipes = RecipeService.GetRecipesByIngredients(new List<String>(ingredients.Split(',')));

                StringBuilder result = new StringBuilder();
                foreach (var recipe in recipes)
                {
                    result.Append("Recipe name: ");
                    result.Append(recipe.RecipeName);
                    result.Append("\n");

                    result.Append("Ingredients: \n");
                    foreach (var i in recipe.IngredientCalorie)
                    {
                        result.Append("\t");
                        result.Append(i.Key);
                        result.Append(" - ");
                        result.Append(i.Value);
                        result.Append(" calorie\n");
                    }

                }

                if (recipes.Count == 0)
                {
                    result.Append("No recipes consist of this ingredients: ");
                }

                var split = ingredients.Split(',');
                for (var i = 0; i < split.Length; i++)
                {
                    var ingredient = split[i];
                    if (i != split.Length - 1)
                    {
                        result.Append(ingredient + ',');
                    }
                    else
                    {
                        result.Append(ingredient + '\n');
                    }
                }

                return result.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}