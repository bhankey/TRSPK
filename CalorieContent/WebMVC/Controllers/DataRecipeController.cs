using System;
using System.Text;
using CalorieContent.Domain.Mapper;
using CalorieContent.Services.Recipe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class DataRecipeController: Controller
    {
        private readonly IRecipeService _recipeService;

        public DataRecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        
        public IActionResult Index(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowOne(string? data)
        {
            var result = new ResultViewModel();
            
            if (data == null)
            {
                result.Error = "Введены не валидные данные";
                
                return View("Index", result);
            }
            
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
            }
            catch (Exception e)
            {
                result.Error = e.Message;
            }
            
            return View("Index", result);
        }

        [HttpPost]
        public ActionResult ShowAll()
        {
            var result = new ResultViewModel();

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

                result.Result = builder.ToString();
            }
            catch (Exception e)
            {
                result.Error = e.Message;
            }

            return View("Index", result);
        }
        
        [HttpPost] 
        public ActionResult Edit(string? recipeName, string? ingredientsString)
        {
            var result = new ResultViewModel();
            
            if (recipeName == null || ingredientsString == null)
            {
                result.Error = "Введены не валидные данные";
                
                return View("Index", result);
            }

            try
            {
                _recipeService.Set(RecipeMapper.StringToRecipe(recipeName, ingredientsString));

                result.Result = "successful";
            }
            catch (Exception e)
            {
                result.Error = e.Message;
            }

            return View("Index", result);
        }

        [HttpPost]
        public ActionResult Delete(string? recipeName)
        {
            var result = new ResultViewModel();
            
            if (recipeName == null)
            {
                result.Error = "Введены не валидные данные";
                
                return View("Index", result);
            }
            
            try
            {
                var status = _recipeService.Delete(recipeName);
                
                result.Result = status ? "Успешно" : "Не существует записи с введенным именем";
            }
            catch (Exception e)
            {
                result.Error = e.Message;
            }
            return View("Index", result);
        }
        
    }
    
}