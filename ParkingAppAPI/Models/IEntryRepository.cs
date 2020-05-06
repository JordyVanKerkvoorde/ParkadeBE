using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAppAPI.Models {
    public interface IEntryRepository {

        IEnumerable<Entry> GetAll(int parkingId);
        Entry GetLatestEntry(int parkingId);
        DataWrapper todayChartData(int parkingId);
    }
}
