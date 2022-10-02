using CarFest.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarFest.DAL.Interfaces
{
    public interface IImageRepository : IRepository<Image>
    {
        Image GetCarImage(int carId);
        Task<List<int>> GetCarImagesIds(int imageId);
        int GetMainImageId(int carId);
        int SetMainImage(int carId, int imageId);
    }
}
