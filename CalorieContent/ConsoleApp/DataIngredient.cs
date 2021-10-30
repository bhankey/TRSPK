using System;
using System.Text;
using CalorieContent.Domain.Mapper;
using CalorieContent.Services.Ingredient;
using CalorieContent.Services.Recipe;

namespace ConsoleApp
{
    public class DataIngredient
    {
        private readonly IIngredientService _ingredientService;
        
        public DataIngredient(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }
        
        public string ShowOne(string data)
        {
            string result;

            try
            {
                var ingredient = _ingredientService.GetItem(data);

                var builder = new StringBuilder();
                builder.Append("Название ингридиента: " + ingredient.Name + "\n");
                builder.Append("Каллорийность на 100 грамм: " + ingredient.CalorieContentPerHundredGrams + "\n");

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
                var ingredients = _ingredientService.GetAll();

                var builder = new StringBuilder();

                foreach (var ingredient in ingredients)
                {
                    builder.Append("Название ингридиента: " + ingredient.Key + "\n");
                    builder.Append("Каллорийность на 100 грамм: " + ingredient.Value.CalorieContentPerHundredGrams + "\n");
                }

                result = builder.ToString();
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            return result;
        }
        
        public string Edit(string ingredientName, string calorieContentPerHundredGrams)
        {
            string result;

            try
            {
                _ingredientService.Set(IngredientMapper.StringToIngredient(ingredientName, calorieContentPerHundredGrams));

                result = "successful";
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            return result;
        }
        
        public string Delete(string ingredientName)
        {
            string result;
            
            try
            {
                var status = _ingredientService.Delete(ingredientName);
                
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