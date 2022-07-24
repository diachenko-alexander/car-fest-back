using Microsoft.AspNetCore.Mvc;
using CarFest.BL.Interfaces;
using CarFest.BL.DTO;
using CarFest.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using CarFest.API.JwtFeatures;
using Microsoft.AspNetCore.Identity;
using CarFest.DAL.Models;
using System.IdentityModel.Tokens.Jwt;

namespace CarFest.API.Controllers
{
    [EnableCors("CarFestCORS")]
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : Controller
    {
        private IUserRegistrationService _userRegistrationService;
        private readonly UserManager<User> _userManager;
        private readonly JwtHandler _jwtHandler;

        public AccountsController(UserManager<User> userManager, IUserRegistrationService userRegistrationService, JwtHandler jwtHandler)
        {
            _userRegistrationService = userRegistrationService;
            _jwtHandler = jwtHandler;
            _userManager = userManager;
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

        [HttpPost("Login")]
        public async Task<IActionResult> Login ([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
            {
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
            }

            var signingcredentials = _jwtHandler.GetSigningCredential();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingcredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token, UserFirstName = user.FirstName });

        }
    }
}
