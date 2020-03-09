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
        #endregion

        #region Methods
        public Entry( DateTime timeDay, int available) {
            TimeDay = timeDay;
            Available = available;
        }
        #endregion
    }
}
