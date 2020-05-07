using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAppAPI.DTO {
    public class SuggestionDTO {
        [Required]
        public string Name { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
        public string Description { get; set; }
    }
}
