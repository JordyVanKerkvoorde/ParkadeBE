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
            return _entries.Where(e => e.ParkingId == parkingId);
        }

        public Entry GetLatestEntry(int parkingId) {
            return _entries.Where(e => e.ParkingId == parkingId).OrderByDescending(e => e.TimeDay).FirstOrDefault();
        }

        public DataWrapper todayChartData(int parkingId) {
            // subtracting 2 hours to account for the 2 hour difference between sql server time and current time
            DateTime timeDelimiter = DateTime.Now.Date.AddHours(-2);
            List<Entry> timeEntries = _entries.Where(e => e.ParkingId == parkingId && e.TimeDay > timeDelimiter).ToList();
            DataWrapper dataObj = new DataWrapper(
                timeEntries.Select(e => e.TimeDay).ToList(),
                timeEntries.Select(e => e.Available).ToList()
                );
            return dataObj;
            throw new NotImplementedException();
        }
    }
}
