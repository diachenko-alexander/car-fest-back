using AutoMapper;
using CarFest.BL.DTO;
using CarFest.BL.Interfaces;
using CarFest.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFest.BL.Services
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IMapper _autoMapper;
        private readonly UserManager<User> _userManager;


        public UserRegistrationService(IMapper mapper, UserManager<User> user)
        {
            _autoMapper = mapper;
            _userManager = user;
            
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDTO userForRegistration)
        {
            if (userForRegistration == null)
            {
                throw new ArgumentNullException("Null argument while creating car");
            }

            var user = _autoMapper.Map<User>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            return result;
           

        }
    }
}
