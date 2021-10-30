using System;
using System.Text;
using CalorieContent.Domain.Mapper;
using CalorieContent.Services.Ingredient;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class DataIngredientController : Controller
    {

        private readonly IIngredientService _ingredientService; 
        public DataIngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
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
                var ingredient = _ingredientService.GetItem(data);

                var builder = new StringBuilder();
                builder.Append("Название ингридиента: " + ingredient.Name + "\n");
                builder.Append("Каллорийность на 100 грамм: " + ingredient.CalorieContentPerHundredGrams + "\n");

                result.Result = builder.ToString();
            }
            catch (Exception e)
            {
                result.Error = e.Message;
            }
            
            return View("Index", result);
        }
        
        public ActionResult ShowAll()
        {
            var result = new ResultViewModel();

            try
            {
                var ingredients = _ingredientService.GetAll();

                var builder = new StringBuilder();

                foreach (var ingredient in ingredients)
                {
                    builder.Append("Название ингридиента: " + ingredient.Key + "\n");
                    builder.Append("Каллорийность на 100 грамм: " + ingredient.Value.CalorieContentPerHundredGrams + "\n");
                }

                result.Result = builder.ToString();
            }
            catch (Exception e)
            {
                result.Error = e.Message;
            }

            return View("Index", result);
        }
        
        public ActionResult Edit(string? ingredientName, string? calorieContentPerHundredGrams)
        {
            var result = new ResultViewModel();
            
            if (ingredientName == null || calorieContentPerHundredGrams == null)
            {
                result.Error = "Введены не валидные данные";
                
                return View("Index", result);
            }

            try
            {
                _ingredientService.Set(IngredientMapper.StringToIngredient(ingredientName, calorieContentPerHundredGrams));

                result.Result = "successful";
            }
            catch (Exception e)
            {
                result.Error = e.Message;
            }

            return View("Index", result);
        }
        
        public ActionResult Delete(string? ingredientName)
        {
            var result = new ResultViewModel();
            
            if (ingredientName == null)
            {
                result.Error = "Введены не валидные данные";
                
                return View("Index", result);
            }
            
            try
            {
                var status = _ingredientService.Delete(ingredientName);
                
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