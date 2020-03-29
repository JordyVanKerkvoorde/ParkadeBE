using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAppAPI.Models {
    public class Entry {
        public int Id { get; set; }
        #region Properties
        public DateTime TimeDay { get; set; }
        public int Available { get; set; }
        public Parking Parking { get; set; }

        #endregion

        #region Methods
        public Entry(int available) {
            TimeDay = DateTime.Now;
            Available = available;
        }
        #endregion
    }
}
