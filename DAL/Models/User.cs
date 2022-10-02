using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CarFest.DAL.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Car> Cars { get; set; }

    }
}
