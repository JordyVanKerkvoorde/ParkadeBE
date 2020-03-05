using ParkingAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAppAPI.Data {
    public class ParkingDataInitializer {
        private readonly ParkingContext _context;

        public ParkingDataInitializer(ParkingContext context) {
            _context = context;
        }

        public void InitializeData() {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated()) {
                var parkings = new List<Parking> {
                    new Parking(2, "Reep", 51.05207, 3.730, 470),
                    new Parking(10, "Sint-Pietersplein", 51.04171, 3.726, 708),
                    new Parking(7, "Sint-Michiels", 51.05367, 3.719, 450),
                    new Parking(1, "Vrijdagmarkt", 51.05652, 3.726, 647),
                    new Parking(4, "Savaanstraat", 51.04862, 3.722, 540),
                    new Parking(8, "Ramen", 51.05532, 3.717, 266)

                };
                _context.AddRange(parkings);
                _context.SaveChanges();
            }
        }
    }
}
