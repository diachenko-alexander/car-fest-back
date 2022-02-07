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

        IEnumerable<TEntity> IRepository<TEntity>.GetAll()
        {
            return _entity;
        }

        Task<IEnumerable<TEntity>> IRepository<TEntity>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity>.Get(int id)
        {
            throw new NotImplementedException();
        }

        Task<TEntity> IRepository<TEntity>.GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity>.Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<TEntity>.Delete(int id)
        {
            throw new NotImplementedException();
        }       

        TEntity IRepository<TEntity>.Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
