using ParkingAppAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAppAPI.Data.Repositories {
    public class ParkingRepository : IParkingRepository {

        private readonly ParkingContext _context;
        private readonly DbSet<Parking> _parkings;
        public ParkingRepository(ParkingContext context) {
            _context = context;
            _parkings = context.Parking;
        }

        public void AddParking(Parking parking) {
            _parkings.Add(parking);
        }

        public void DeleteParking(Parking parking) {
            _parkings.Remove(parking);
        }

        public IEnumerable<Parking> GetAll() {
            return _parkings.ToList();
        }

        public Parking GetParkingById(int id) {
            return _parkings.SingleOrDefault(p => p.Id == id);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

        public void UpdateParking(Parking parking) {
            _context.Update(parking);
        }
    }
}
