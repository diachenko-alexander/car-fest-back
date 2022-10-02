using CarFest.BL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarFest.BL.Interfaces
{
    public interface IImageService
    {
        ImageDTO GetCarImage(int imageId);
        Task<List<int>> GetCarImagesIds(int carId);
        void SaveCarImage(ImageDTO image);
        void DeleteCarImage(int id);
        int GetMainImageId(int carId);
        int SetMainImage(int carId, int imageId);
    }
}
