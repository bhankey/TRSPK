using System;
using System.Collections.Generic;
using System.Linq;
using CalorieContent.Domain.Enums;
using CalorieContent.Domain.Mapper;
using CalorieContent.lib.KeyValueStorage;

namespace CalorieContent.Repositories.Ingredient
{
    public class IngredientRepo : IIngredientRepo
    {
        private const int IngredientDB = (int) DBNumbers.Ingredient;

        private readonly IStorage _storage;

        public IngredientRepo(IStorage storage)
        {
            _storage = storage ?? throw new Exception("empty storage receive");
        }

        public Domain.Entities.Ingredient Get(string name)
        {
            _storage.GetString(IngredientDB, name, out var value);

            return IngredientMapper.StringToIngredient(name, value);
        }

        public Dictionary<string, Domain.Entities.Ingredient> GetAll()
        {
            var values = _storage.GetAllStrings(IngredientDB);

            var result = values.ToDictionary(value => value.Key,
                value => IngredientMapper.StringToIngredient(value.Key, value.Value));

            return result;
        }

        public void Set(Domain.Entities.Ingredient entity)
        {
            _storage.SetString(IngredientDB, entity.Name, entity.CalorieContentPerHundredGrams.ToString());
        }

        public bool Delete(string name)
        {
            return _storage.TryDelete(IngredientDB, name);
        }
    }
}