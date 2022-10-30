using CarFest.BL.DTO;
using CarFest.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarFest.API.Controllers
{
    [EnableCors("CarFestCORS")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("UserInfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);            
            return Ok(new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            });
        }

        [HttpPost("ChangeUserPassword")]
        public async Task<IActionResult> ChangeUserPassword([FromBody] string oldPassword, string newPassword)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            try
            {
                await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }
    }
}
