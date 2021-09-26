using System;
using System.Text;
using CalorieContent.Domain.Entities;

namespace CalorieContent.Domain.Mapper
{
    public static class RecipeMapper
    {
        public static Recipe StringToRecipe(string name, string value)
        {
            var values = value.Trim().Split(';');

            if (values.Length < 2 || values.Length % 2 != 0)
                throw new Exception("wrong string in constructor of Recipe");


            var ingredients = new RecipeIngredient[values.Length / 2];
            for (var i = 0; i < values.Length; i += 2)
            {
                ingredients[i / 2].Name = values[i];
                ingredients[i / 2].Grams = int.Parse(values[i + 1]);
            }

            return new Recipe(name, ingredients);
        }

        public static string RecipeToString(Recipe value)
        {
            var result = new StringBuilder("\"" + value.Name + "\":\"");

            foreach (var t in value.Ingredients)
            {
                result.Append(t.Name);
                result.Append(';');
                result.Append(t.Grams);
            }

            result.Append('\"');
            return result.ToString();
        }
    }
}