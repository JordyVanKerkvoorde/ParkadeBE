using ParkingAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAppAPI.DTO {
    public class ParkUserDTO {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }


        public ParkUserDTO() { }

        public ParkUserDTO(ParkUser user) : this() {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
        }
    }
}
