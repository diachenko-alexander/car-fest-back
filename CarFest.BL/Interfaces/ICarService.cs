using CarFest.BL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarFest.BL.Interfaces
{
    public interface ICarService : IService<CarDTO>, IServiceAsync<CarDTO>
    {
        Task<IEnumerable<CarDTO>> GetUserCarsAsync(string userId);
        CarDTO GetUserCar(int carId, string userId);
        void DeleteUserCar(int id, string userId);

    }
}
