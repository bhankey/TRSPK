using System.Collections.Generic;

namespace CalorieContent.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        public T Get(string name);
        public Dictionary<string, T> GetAll();
        public void Set(T entity);
        public bool Delete(string name);
    }
}