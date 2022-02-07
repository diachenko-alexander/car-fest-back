using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFest.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRepository CarRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
