using CarFest.BL.DTO;
using CarFest.BL.Interfaces;
using CarFest.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CarFest.API.Controllers
{
    [EnableCors("CarFestCORS")]
    //[Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private ICarService _carService;
        private readonly UserManager<User> _userManager;

        public ImagesController(IImageService imageService, ICarService carService, UserManager<User> userManager)
        {
            _imageService = imageService;
            _carService = carService;
            _userManager = userManager;
        }
        
        [HttpPost]
        [Route("api/Images/save-image")]
        public async Task<IActionResult> SaveImage(IFormCollection data, IFormFile imageFile)
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            StringValues carId;

            if (data.TryGetValue("carId", out carId))
            {
                var car = _carService.GetUserCar(int.Parse(carId), user.Id);
                if (car == null)
                {
                    return NotFound();
                }
                else
                {
                    ImageDTO imageDTO = new ImageDTO();
                    imageDTO.ImageTitle = imageFile.FileName;
                    imageDTO.CarId = int.Parse(carId);

                    MemoryStream ms = new MemoryStream();
                    imageFile.CopyTo(ms);
                    imageDTO.ImageDate = ms.ToArray();
                    ms.Close();
                    ms.Dispose();
                    _imageService.SaveCarImage(imageDTO);
                }
            }
            return Ok();
        }
        
        [HttpGet]
        [Route("api/Images/get-images-ids")]
        public async Task<IActionResult> GetCarImagesIds (int carId)
        {
            return Ok(await _imageService.GetCarImagesIds(carId));
        }

        [HttpGet]
        [Route("api/Images/get-image")]
        public async Task<IActionResult> GetImage (int imageId)
        {
            var image = _imageService.GetCarImage(imageId);           
            return File(image.ImageDate, "image/jpeg");
        }

        [HttpDelete]
        [Route("api/Images/delete-image")]
        public async Task<IActionResult> DeleteImage (int imageId)
        {
            try
            {
                _imageService.DeleteCarImage(imageId);
            } catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("api/Images/get-main-image-id")]
        public IActionResult GetMainImageId(int carId)
        {
            // var user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            try
            {
               return Ok (_imageService.GetMainImageId(carId));
            } catch (Exception e)
            {
                return Ok (-1);
            }
        }

        [HttpGet]
        [Route("api/Images/set-main-image")]
        public IActionResult SetMainImage (int carId, int imageId)
        {
            _imageService.SetMainImage(carId, imageId);
            return Ok (_imageService.SetMainImage(carId, imageId));
        }

    }
}
