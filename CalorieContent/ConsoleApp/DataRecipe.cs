using System;
using System.Text;
using CalorieContent.Domain.Mapper;
using CalorieContent.Services.Recipe;

namespace ConsoleApp
{
    public class DataRecipe
    {
        private readonly IRecipeService _recipeService;

        public DataRecipe(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        
        public string ShowOne(string data)
        {
            string result;

            try
            {
                var recipe = _recipeService.GetItem(data);

                var builder = new StringBuilder();
                builder.Append("Название рецепта: " + recipe.Name + "\n");
                builder.Append("Ингредиенты:\n");
                foreach (var ingredient in recipe.Ingredients)
                {
                    builder.Append("\t" + ingredient.Name + " : " +
                                   ingredient.Grams.ToString() + "г\n");
                }

                result = builder.ToString();
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            return result;
        }

        public string ShowAll()
        {
            string result; 

            try
            {
                var recipes = _recipeService.GetAll();

                var builder = new StringBuilder();

                foreach (var recipe in recipes)
                {
                    builder.Append("Название рецепта: " + recipe.Key + "\n");
                    builder.Append("Ингредиенты:\n");
                    foreach (var ingredient in recipe.Value.Ingredients)
                    {
                        builder.Append("\t" + ingredient.Name + " : " +
                                       ingredient.Grams.ToString() + "г\n");
                    }
                }

                result = builder.ToString();
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            return result;
        }
        
        public string Edit(string recipeName, string ingredientsString)
        {
            string result;

            try
            {
                _recipeService.Set(RecipeMapper.StringToRecipe(recipeName, ingredientsString));

                result = "successful";
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            return result;
        }
        
        public string Delete(string recipeName)
        {
            string result;

            try
            {
                var status = _recipeService.Delete(recipeName);
                
                result = status ? "Успешно" : "Не существует записи с введенным именем";
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }
    }
}