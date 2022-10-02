using AutoMapper;
using CarFest.BL.DTO;
using CarFest.BL.Interfaces;
using CarFest.DAL.Interfaces;
using CarFest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarFest.BL.Services
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _autoMapper;

        public ImageService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _autoMapper = mapper;
        }

        public ImageDTO GetCarImage(int imageId)
        {
            return _autoMapper.Map<ImageDTO>(_db.ImageRepository.GetCarImage(imageId));
        }

        public async Task<List<int>> GetCarImagesIds(int carId)
        {
            return await _db.ImageRepository.GetCarImagesIds(carId);
        }

        public void SaveCarImage(ImageDTO entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Null argument while creating image");
            }

            var image = _autoMapper.Map<Image>(entity);
            image.CarId = entity.CarId;
            image.ImageTitle = entity.ImageTitle;
            image.ImageDate = entity.ImageDate;
            image.IsMainImage = false;

            _db.ImageRepository.Create(image);
            _db.Save();
        }

        public void DeleteCarImage(int id)
        {
            var image = _db.ImageRepository.Get(id);
            if (image == null)
            {
                throw new ArgumentNullException($"No such car image with Id: {id}");
            }

            _db.ImageRepository.Delete(id);
            _db.Save();
        }

        public int GetMainImageId(int carId)
        {

          return _db.ImageRepository.GetMainImageId(carId);

        }

        public int SetMainImage(int carId, int imageId)
        {
           return _db.ImageRepository.SetMainImage(carId, imageId);
        }
    }
}
