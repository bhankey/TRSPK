using System.Text;
using CalorieContent.Domain.Mapper;
using CalorieContent.Services.Recipe;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class DataRecipeController: Controller
    {
        private readonly IRecipeService RecipeService;

        public DataRecipeController(IRecipeService recipeService)
        {
            RecipeService = recipeService;
        }
        
        // GET: /Business
        public IActionResult Index(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowOne(string? data)
        {
            if (data == null)
            {
                return View("Index");
            }

            var recipe = RecipeService.GetItem(data);

            var builder = new StringBuilder();
            builder.Append("Название рецепта: " + recipe.Name + "\n");
            builder.Append("Ингридиенты:\n");
            foreach (var ingredient in recipe.Ingredients)
            {
                builder.Append("\t" + ingredient.Name + " : " +
                               ingredient.Grams.ToString() + "г\n");
            }

            var result = new ResultViewModel();

            result.Result = builder.ToString();
            
            return View("Index", result);
        }

        [HttpPost]
        public ActionResult ShowAll()
        {
            var recipes = RecipeService.GetAll();

            var builder = new StringBuilder();

            foreach (var recipe in recipes)
            {
                builder.Append("Название рецепта: " + recipe.Key + "\n");
                builder.Append("Ингридиенты:\n");
                foreach (var ingredient in recipe.Value.Ingredients)
                {
                    builder.Append("\t" + ingredient.Name + " : " +
                                   ingredient.Grams.ToString() + "г\n");
                }
            }
            
            var result = new ResultViewModel();

            result.Result = builder.ToString();

            return View("Index", result);
        }
        
        public ActionResult Edit(string? recipeName, string? ingredientsString)
        {
            if (recipeName == null || ingredientsString == null)
            {
                return View("Index");
            }
            
            RecipeService.Set(RecipeMapper.StringToRecipe(recipeName, ingredientsString));

            var result = new ResultViewModel();

            result.Result = "successful";

            return View("Index", result);
        }
        
        public ActionResult Delete(string? recipeName)
        {
            if (recipeName == null)
            {
                return View("Index");
            }
            
            var status = RecipeService.Delete(recipeName);

            var result = new ResultViewModel();

            result.Result = status? "Успешно": "Не успешно";

            return View("Index", result);
        }
    }
}