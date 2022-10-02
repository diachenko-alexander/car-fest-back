using System;
using System.Threading.Tasks;

namespace CarFest.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository CarRepository { get; }
        IImageRepository ImageRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
