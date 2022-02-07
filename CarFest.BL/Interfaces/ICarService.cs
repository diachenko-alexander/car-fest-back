using CarFest.BL.DTO;
using CarFest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFest.BL.Interfaces
{
    public interface ICarService : IService<CarDTO>, IServiceAsync<CarDTO>
    {

    }
}
