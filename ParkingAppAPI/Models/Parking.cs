using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAppAPI.Models {
    public class Parking {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        //X-AS
        public double? Latitude { get; set; }
        //Y-AS
        public double? Longtitude { get; set; }
        public int MaxCap { get; set; }
        public Entry LatestEntry { get; set; }
        #endregion

        #region Methods
        public Parking(int id, string name, double latitude, double longtitude, int maxCap, string type) {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longtitude = longtitude;
            MaxCap = maxCap;
            Type = type;
        }

        public Parking(int id, string name, int maxCap, string type) {
            Id = id;
            Name = name;
            MaxCap = maxCap;
            Type = type;
        }
        #endregion
    }
}
