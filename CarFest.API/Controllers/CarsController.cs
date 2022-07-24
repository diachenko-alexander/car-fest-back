using CarFest.BL.Interfaces;
using CarFest.BL.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CarFest.API.Controllers
{
    [EnableCors("CarFestCORS")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_carService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var car = _carService.Get(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public IActionResult Create (CarDTO car)
        {
            _carService.Create(car);
            return CreatedAtAction(nameof(Get), new {id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CarDTO car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _carService.Update(car);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _carService.Delete(id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            return NoContent();
        }


        //[HttpGet]
        //public async Task<ActionResult> GetAllAsync()
        //{
        //    var result = await _carService.GetAllAsync();
        //    return Ok(result);
        //}

    }
}
