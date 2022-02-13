using CarFest.BL.Interfaces;
using CarFest.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarFest.BL.DTO;
using CarFest.DAL.Models;

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

        public CarDTO Get(int id)
        {
            return _autoMapper.Map<CarDTO>(_db.CarRepository.Get(id));
        }

        public async Task<CarDTO> GetAsync(int id)
        {
            return _autoMapper.Map<CarDTO>(await _db.CarRepository.GetAsync(id));
        }

        public CarDTO Create(CarDTO entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Null argument while creating car");
            }
            var car = _autoMapper.Map<Car>(entity);
            car.Model = entity.Model;
            car.Name = entity.Name;
            car.Price = entity.Price;

            _db.CarRepository.Create(car);
            _db.Save();
            return entity;
        }

        public async Task<CarDTO> CreateAsync(CarDTO entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Null argument while async creating car");
            }
            var car = _autoMapper.Map<Car>(entity);
            car.Model = entity.Model;
            car.Name = entity.Name;
            car.Price = entity.Price;

            _db.CarRepository.Create(car);
            await _db.SaveAsync();
            return entity;
        }

        public CarDTO Update(CarDTO entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Null argument while updating car");
            }

            var car = _db.CarRepository.Get(entity.Id);
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

    }
}