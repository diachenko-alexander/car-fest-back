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
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using CarFest.DAL.Models;

namespace CarFest.API.Controllers
{
    [EnableCors("CarFestCORS")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;
        private readonly UserManager<User> _userManager;        
        public CarsController(ICarService carService, UserManager<User> userManager)
        {
            _carService = carService;
            _userManager = userManager;
            
        }      
       
        [HttpGet]
        public async Task<OkObjectResult> GetAll()
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);            

            return Ok(await _carService.GetUserCarsAsync(user.Id));
        }        

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var car = _carService.GetUserCar(id, user.Id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarDTO car)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            await _carService.CreateAsync(car, user.Id);
            return CreatedAtAction(nameof(Get), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CarDTO car)
        {

            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            if (id != car.Id)
            {
                return BadRequest();
            }

            _carService.Update(car, user.Id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            try
            {
                _carService.DeleteUserCar(id, user.Id);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            return NoContent();
        }     
    }
}
