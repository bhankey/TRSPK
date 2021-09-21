using System;
using CalorieContent.Domain.Entities;

namespace CalorieContent.Domain.Mapper
{
    public static class IngredientMapper
    {
        public static Ingredient StringToIngredient(string value)
        {
            var values = value.Trim().Split(';');

            if (value.Length != 2)
            {
                throw new Exception("wrong string in constructor of Ingredient");
            }

            return new Ingredient(values[0], int.Parse(values[1]));
        }
        
        public static string IngredientToString(Ingredient value)
        {
            return value.Name + ":" + value.CalorieContentPerHundredGrams;
        }
    }
}