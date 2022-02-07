using AutoMapper;
using CarFest.DAL.Models;
using CarFest.BL.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFest.BL.Configuration
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Car, CarDTO>().ReverseMap();
        }
       
    }
}
