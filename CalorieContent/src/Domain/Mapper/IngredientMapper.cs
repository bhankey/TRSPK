using System;
using CalorieContent.Domain.Entities;

namespace CalorieContent.Domain.Mapper
{
    public static class IngredientMapper
    {
        public static Ingredient StringToIngredient(string name, string value)
        {
            return new Ingredient(name, int.Parse(value.Trim()));
        }
        
        public static string IngredientToString(Ingredient value)
        {
            return value.Name + ":" + value.CalorieContentPerHundredGrams;
        }
    }
}