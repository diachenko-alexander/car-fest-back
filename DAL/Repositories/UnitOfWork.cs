using CarFest.DAL.Interfaces;
using System;
using System.Threading.Tasks;
using DAL.Context;

namespace CarFest.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed;

        private ICarRepository _carRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;     
        }

        public ICarRepository CarRepository => _carRepository
            ?? (_carRepository = new CarRepository(_context));

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose (bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
