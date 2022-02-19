using CarFest.BL.DTO;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CarFest.BL.Interfaces
{
    public interface IUserRegistrationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDTO user);
    }
}
