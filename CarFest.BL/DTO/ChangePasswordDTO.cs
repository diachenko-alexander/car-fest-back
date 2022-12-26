using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFest.BL.DTO
{
    public class ChangePasswordDTO
    {
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
