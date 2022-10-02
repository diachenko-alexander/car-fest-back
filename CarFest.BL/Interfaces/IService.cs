using System.Collections.Generic;

namespace CarFest.BL.Interfaces
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Create(T entity, string userId);
        T Update(T entity, string userId);
        void Delete(int id);
    }
}
