using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAppAPI.Models {
    public class Suggestion {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public string Description { get; set; }
        //maybe add enumtype to see specify if the suggestion was implemented/trashed/notb

        public Suggestion(int id, string name, double longtitude, double latitude, string description) {
            Id = id;
            Name = name;
            Longtitude = longtitude;
            Latitude = latitude;
            Description = description;
        }

        public Suggestion() {
        }
    }
}
