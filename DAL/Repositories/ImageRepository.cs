using CarFest.DAL.Interfaces;
using CarFest.DAL.Models;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarFest.DAL.Repositories
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Image GetCarImage(int imageId)
        {
            var carImage = _context
                .Images
                .Where(x => x.Id == imageId)
                .FirstOrDefault();
            return carImage;
                
        }

        public async Task<List<int>> GetCarImagesIds(int carId)
        {
            var carImagesIds = _context
                .Images
                .Where(x => x.CarId == carId)
                .Select(x => x.Id);
            return await carImagesIds.ToListAsync();
        }

        public int GetMainImageId(int carId)
        {
            var mainCarImage = _context
                .Images
                .Where(x => x.CarId == carId)
                .Where(x => x.IsMainImage == true)
                .Select(x => x.Id);
            return mainCarImage.First();
        }

        public int SetMainImage(int carId, int imageId)
        {
            var images = _context
                .Images
                .Where(x => x.CarId == carId)
                .ToList();
            images.ForEach(x => x.IsMainImage = false);
            var mainImage = images
                .Where(x => x.CarId == carId && x.Id == imageId)
                .FirstOrDefault();
            mainImage.IsMainImage = true;
            _context.SaveChanges();
            return GetMainImageId(carId);
        }
    }
}
