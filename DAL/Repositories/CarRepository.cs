using CarFest.DAL.Models;
using CarFest.DAL.Interfaces;
using DAL.Context;

namespace CarFest.DAL.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
