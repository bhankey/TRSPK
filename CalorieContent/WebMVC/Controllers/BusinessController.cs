using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CalorieContent.Services.Recipe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMVC.Models;


namespace WebMVC.Controllers
{
    public class BusinessController : Controller
    {
        private readonly IRecipeService RecipeService;

        public BusinessController(IRecipeService recipeService)
        {
            RecipeService = recipeService;
        }
        
        // GET: /Business
        public IActionResult Index(int? id, string Input, int? ServiceType)
        {
            var d = RecipeService.GetItem("database");
            ViewData["Message"] = $"Hello + {Input} + {ServiceType} + {d}";
            Console.WriteLine($"{{id}},{Input}, {ServiceType}\n");
            return View();
        }
        
        // GET: /Business/Action

    }
}