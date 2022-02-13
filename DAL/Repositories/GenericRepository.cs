using CarFest.DAL.Interfaces;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFest.DAL.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<TEntity> _entity;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entity;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public TEntity Get(int id)
        {
            return _entity.Find(id);
        }

        public Task<TEntity> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity Create(TEntity entity)
        {
            _entity.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            TEntity entity = _entity.Find(id);
            if (entity != null)
            {
                _entity.Remove(entity);
            }
        }       

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            _entity.Update(entity);
            return entity;
        }
    }
}
