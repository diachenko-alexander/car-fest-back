using CarFest.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarFest.DAL.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<List<Car>> GetUserCarsAsync(string id);
        Car GetUserCar(int carId, string userId);
        void DeleteUserCar(int id, string userId);

    }
}
