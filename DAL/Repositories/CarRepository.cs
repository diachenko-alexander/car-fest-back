using CarFest.DAL.Models;
using CarFest.DAL.Interfaces;
using DAL.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CarFest.DAL.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(ApplicationDbContext context) : base(context)
        {

        }

        public void DeleteUserCar(int id, string userId)
        {
            Car entity = _entity.Find(id);
            if (entity != null && entity.UserId == userId)
            {
                _entity.Remove(entity);
            }
        }

        public Car GetUserCar(int carId, string userId)
        {
            var userCar = _context
                .Cars
                .Where(x => x.Id == carId && x.UserId == userId)
                .FirstOrDefault();
            return userCar;
        }

        public async Task<List<Car>> GetUserCarsAsync(string userId)
        {
            var usersCars = _context
                .Cars
                .Where(x => x.UserId == userId);                
            return await usersCars.ToListAsync();
        }       
    }
}
