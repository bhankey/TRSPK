using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CalorieContent.Core.Repositories.Base;
using CalorieContent.Domain.Entities;
using CalorieContent.Domain.Enums;
using CalorieContent.Domain.Mapper;
using CalorieContent.lib.KeyValueStorage;

namespace CalorieContent.Core.Repositories
{
    public class IngredientRepo: IRepository<Ingredient>
    {
        private const int IngredientDB = (int) DBNumbers.Ingredient; 
        
        private readonly Storage _storage;

        public IngredientRepo(Storage storage)
        {
            _storage = storage ?? throw new Exception("empty storage receive");
        }
        
        public Task<Ingredient> Get(string name)
        {
            _storage.TryGetString(IngredientDB, name, out string value);
            
            return Task.FromResult(IngredientMapper.StringToIngredient(value));
        }

        public Task<Dictionary<string, string> > GetAll()
        {
           return new Task<Dictionary<string, string>>(() => _storage.GetAllStrings(IngredientDB));
        }

        public void Set(Ingredient entity)
        {
            _storage.SetString(IngredientDB, entity.Name, entity.CalorieContentPerHundredGrams.ToString());
        }

        public Task<bool> Delete(string name)
        {
            return new Task<bool>(() => _storage.TryDelete(IngredientDB, name));
        }
    }
}