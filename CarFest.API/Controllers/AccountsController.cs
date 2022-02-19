using Microsoft.AspNetCore.Mvc;
using CarFest.BL.Interfaces;
using CarFest.BL.DTO;
using CarFest.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace CarFest.API.Controllers
{
    [EnableCors("CarFestCORS")]
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : Controller
    {
        private IUserRegistrationService _userRegistrationService;

        public AccountsController(IUserRegistrationService userRegistrationService)
        {
            _userRegistrationService = userRegistrationService;
        }
            
        
        [HttpPost("registration")]
        public IActionResult RegisterUser(UserForRegistrationDTO userForRegistration)
        {
            try
            {                
                var user = _userRegistrationService.RegisterUser(userForRegistration);
                if (!user.Result.Succeeded)
                {
                    var errors = user.Result.Errors.Select(e => e.Description);
                    return BadRequest(new RegistrationResponseDto { Errors = errors });
                }
                return StatusCode(201);

            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }   
            

           
        }
    }
}
