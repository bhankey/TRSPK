using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalorieContent.Core.Repositories.Base
{
    public interface IRepository <T> where T: class
    {
        // Чтобы получить из таска нужный объект
        public Task <T> Get(string name);
        public Task<Dictionary<string, string>> GetAll();
        public void Set(T entity);
        public Task<bool> Delete(string name);

    }
}