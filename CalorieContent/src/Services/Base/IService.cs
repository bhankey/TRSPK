using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalorieContent.Services.Base
{
    public interface IService<T>
    {
        public T GetItem(string item);

        public Dictionary<string, T> GetAll();

        public void Set(T entity);

        public bool Delete(string name);
    }
}