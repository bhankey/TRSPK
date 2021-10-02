using System.Collections.Generic;
using CalorieContent.Repositories.Ingredient;

namespace CalorieContent.Services.Ingredient
{
    public class IngredientService : IIngredientService
    {
        private readonly IngredientRepo _ingredientRepo;

        public IngredientService(IngredientRepo repo)
        {
            _ingredientRepo = repo;
        }


        public Domain.Entities.Ingredient GetItem(string item)
        {
            return _ingredientRepo.Get(item);
        }

        public Dictionary<string, Domain.Entities.Ingredient> GetAll()
        {
            return _ingredientRepo.GetAll();
        }

        public void Set(Domain.Entities.Ingredient entity)
        {
            _ingredientRepo.Set(entity);
        }

        public bool Delete(string name)
        {
            return _ingredientRepo.Delete(name);
        }
    }
}