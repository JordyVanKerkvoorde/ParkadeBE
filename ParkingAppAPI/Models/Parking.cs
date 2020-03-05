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
        public double Latitude { get; set; }
        //Y-AS
        public double Longtitude { get; set; }
        public int MaxCap { get; set; }
        public ICollection<Entry> Entries { get; set; }
        #endregion

        #region Methods
        public Parking(int id, string name, double latitude, double longtitude, int maxCap) {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longtitude = longtitude;
            MaxCap = maxCap;
            Entries = new List<Entry>();
        }

        public void AddEntry(Entry entry) {
            Entries.Add(entry);
        }

        public void AddRandomEntry() {
            Entries.Add(NewRandomEntry());
        }

        public Entry GetEntry(DateTime time) {
            return Entries.SingleOrDefault(e => e.TimeDay == time);
        }

        public Entry GetLatestEntry() {
            return Entries.OrderBy(e => e.TimeDay.TimeOfDay)
                    .ThenBy(e => e.TimeDay.Date)
                    .ThenBy(e => e.TimeDay.Year).FirstOrDefault();
        }

        public Entry NewRandomEntry() {
            DateTime now = DateTime.Now;
            int capacity;
            Random r = new Random();
            if (!Entries.Any()) {
                capacity = r.Next(100, MaxCap);
            } else {
                capacity = GetLatestEntry().Occupied + r.Next(0, 20) - r.Next(0, 20);
                if (capacity > MaxCap) {
                    capacity = MaxCap;
                }
                if (capacity < 0) {
                    capacity = 0;
                }
            }
            return new Entry(now, capacity);
        }
        #endregion
    }
}
