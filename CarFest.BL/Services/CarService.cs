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
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _autoMapper;

        public CarService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _autoMapper = mapper;
        }

        public IEnumerable<CarDTO> GetAll()
        {
            return _autoMapper.Map<IEnumerable<CarDTO>>(_db.CarRepository.GetAll());
        }

        public async Task<IEnumerable<CarDTO>> GetAllAsync()
        {
            return _autoMapper.Map<IEnumerable<CarDTO>>(await _db.CarRepository.GetAllAsync());
        }

        public async Task<IEnumerable<CarDTO>> GetUserCarsAsync(string userId)
        {
            return _autoMapper.Map<IEnumerable<CarDTO>>(await _db.CarRepository.GetUserCarsAsync(userId));
        }

        public CarDTO GetUserCar(int carId, string userId)
        {
            return _autoMapper.Map<CarDTO>(_db.CarRepository.GetUserCar(carId, userId));
        }

        public CarDTO Get(int id)
        {
            return _autoMapper.Map<CarDTO>(_db.CarRepository.Get(id));
        }

        public async Task<CarDTO> GetAsync(int id)
        {
            return _autoMapper.Map<CarDTO>(await _db.CarRepository.GetAsync(id));
        }


        public CarDTO Create(CarDTO entity, string userId)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Null argument while creating car");
            }
            var car = _autoMapper.Map<Car>(entity);
            car.Model = entity.Model;
            car.Name = entity.Name;
            car.Price = entity.Price;
            car.UserId = userId;

            _db.CarRepository.Create(car);
            _db.Save();
            return entity;
        }

        public async Task<CarDTO> CreateAsync(CarDTO entity, string userId)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Null argument while async creating car");
            }
            var car = _autoMapper.Map<Car>(entity);
            car.Model = entity.Model;
            car.Name = entity.Name;
            car.Price = entity.Price;
            car.UserId = userId;

            _db.CarRepository.Create(car);
            await _db.SaveAsync();
            return entity;
        }

        public CarDTO Update(CarDTO entity, string userId)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Null argument while updating car");
            }

            var car = _db.CarRepository.Get(entity.Id);
            if (car.UserId != userId)
            {
                throw new ArgumentNullException("Null argument while updating car");
            }
            car.Model = entity.Model;
            car.Name = entity.Name;
            car.Price = entity.Price;

            _db.CarRepository.Update(car);
            _db.Save();
            return entity;
        }

        public void Delete(int id)
        {
            var car = _db.CarRepository.Get(id);
            if (car == null)
            {
                throw new ArgumentNullException($"No such car with Id: {id}");
            }

            _db.CarRepository.Delete(id);
            _db.Save();
        }

        public void DeleteUserCar(int id, string userId)
        {
            var car = _db.CarRepository.GetUserCar(id, userId);
            if (car == null)
            {
                throw new ArgumentNullException($"No such car with Id: {id}");
            }

            _db.CarRepository.DeleteUserCar(id, userId);
            _db.Save();
        }
    }
}