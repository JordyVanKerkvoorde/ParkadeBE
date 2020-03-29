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
        public string? Latitude { get; set; }
        //Y-AS
        public string? Longtitude { get; set; }
        public int MaxCap { get; set; }
        #endregion

        #region Methods
        public Parking(int id, string name, string latitude, string longtitude, int maxCap, string type) {
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



            /*public Entry GetEntry(DateTime time) {
                return Entries.SingleOrDefault(e => e.TimeDay == time);
            }*/

            /*public Entry GetLatestEntry() {
                return Entries.OrderBy(e => e.TimeDay.TimeOfDay)
                        .ThenBy(e => e.TimeDay.Date)
                        .ThenBy(e => e.TimeDay.Year).FirstOrDefault();
            }*/
            #endregion
        }
    }
}
