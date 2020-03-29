using Microsoft.EntityFrameworkCore;
using ParkingAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAppAPI.Data.Repositories {
    public class EntryRepository : IEntryRepository {
        private readonly ParkingContext _context;
        private readonly DbSet<Entry> _entries;

        public EntryRepository(ParkingContext context) {
            _context = context;
            _entries = context.Entry;
        }
        public IEnumerable<Entry> GetAll(int parkingId) {
            return _entries.Where(e => e.Parking.Id == parkingId).Include(e => e.Parking);
        }

        public Entry GetLatestEntry(int parkingId) {
            return _entries.Where(e => e.Parking.Id == parkingId).OrderByDescending(e => e.TimeDay).FirstOrDefault();
        }

        public List<(DateTime, int)> LastWeek(int parkingId) {
            throw new NotImplementedException();
        }
    }
}
