using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarFest.DAL.Interfaces
{
   public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        TEntity Get(int id);
        Task<TEntity> GetAsync(int id);
        TEntity Create(TEntity entity);
        Task<TEntity> CreateAsync(TEntity entity);
        TEntity Update(TEntity entity);
        //Task<TEntity> UpdateAsync(TEntity entity);
        void Delete (int id);
        //Task DeleteAsync(int id);
    }
}
