using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalorieContent.Services.Recipe;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMVC.Models;


namespace WebMVC.Controllers
{
    public class BusinessController : Controller
    {
        private enum serviceType
        {
            RecipeDetails = 1,
            LowerCalorieContentThan = 2,
            ConsistOf = 3,
        }
        
        private readonly IRecipeService RecipeService;

        public BusinessController(IRecipeService recipeService)
        {
            RecipeService = recipeService;
        }
        
        // GET: /Business
        public IActionResult Index(int? id, string input, int? choose)
        {
            if (choose == null || string.IsNullOrEmpty(input))
            {
                return View();
            }

            var serviceType = (serviceType)choose;
            
            switch (serviceType)
            {
                case serviceType.RecipeDetails:
                {
                    try
                    {
                        var recipe = RecipeService.DescribeRecipe(input);

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

                        ViewData["ResultOfService"] = result.ToString();
                    }
                    catch (Exception e)
                    {
                        ViewData["ResultOfService"] = e.Message;
                    }

                    break;   
                }
                case serviceType.LowerCalorieContentThan:
                {
                    try
                    {
                        var recipes = RecipeService.GetLessSumCalorie(int.Parse(input));

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
                            result.Append("No recipes lower than that calorie: " + int.Parse(input));
                        }

                        ViewData["ResultOfService"] = result.ToString();
                    }
                    catch (Exception e)
                    {
                        ViewData["ResultOfService"] = e.Message;
                    }

                    break;
                }
                case serviceType.ConsistOf:
                {
                    try
                    {
                        var recipes = RecipeService.GetRecipesByIngredients(new List<String>(input.Split(',')));

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

                        var split = input.Split(',');
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

                        ViewData["ResultOfService"] = result.ToString();
                    }
                    catch (Exception e)
                    {
                        ViewData["ResultOfService"] = e.Message;
                    }

                    break;
                }
            }
            return View();
        }
    }
}