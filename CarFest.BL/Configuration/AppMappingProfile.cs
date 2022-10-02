using AutoMapper;
using CarFest.BL.DTO;
using CarFest.DAL.Models;

namespace CarFest.BL.Configuration
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Car, CarDTO>().ReverseMap();
            CreateMap<UserForRegistrationDTO, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
            CreateMap<Image, ImageDTO>().ReverseMap();
        }

    }
}
