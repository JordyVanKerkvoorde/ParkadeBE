using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAppAPI.Models {
    public class DataWrapper {

        public IEnumerable<DateTime> TimeData { get; set; }
        public IEnumerable<int> CapacityData { get; set; }

        public DataWrapper() {
        }

        public DataWrapper(List<DateTime> timeData, List<int> capacityData) {
            TimeData = timeData;
            CapacityData = capacityData;
        }


    }
}
