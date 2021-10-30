using System;
using System.Collections.Generic;
using System.Linq;
using CalorieContent.Domain.Enums;
using CalorieContent.Domain.Mapper;
using CalorieContent.lib.KeyValueStorage;

namespace CalorieContent.Repositories.Recipe
{
    public class RecipeRepo : IRecipeRepo
    {
        private const int RecipeDB = (int) DBNumbers.Recipe;

        private readonly Storage _storage;

        public RecipeRepo(Storage storage)
        {
            _storage = storage ?? throw new Exception("empty storage receive");
        }

        public Domain.Entities.Recipe Get(string name)
        {
            _storage.GetString(RecipeDB, name, out var value);

            return RecipeMapper.StringToRecipe(name, value);
        }

        public Dictionary<string, Domain.Entities.Recipe> GetAll()
        {
            var values = _storage.GetAllStrings(RecipeDB);

            var result = values.ToDictionary(
                value => value.Key,
                value => RecipeMapper.StringToRecipe(value.Key, value.Value));

            return result;
        }

        public void Set(Domain.Entities.Recipe entity)
        {
            _storage.SetString(RecipeDB, entity.Name, RecipeMapper.ValueRecipeToString(entity));
        }

        public bool Delete(string name)
        {
            return _storage.TryDelete(RecipeDB, name);
        }
    }
}