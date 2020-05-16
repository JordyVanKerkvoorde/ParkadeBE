using Microsoft.EntityFrameworkCore;
using ParkingAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAppAPI.Data.Repositories {
    public class ParkUserRepository : IParkUserRepository {
        private readonly ParkingContext _context;
        private readonly DbSet<ParkUser> _users;

        public ParkUserRepository(ParkingContext context) {
            _context = context;
            _users = context.ParkUser;
        }

        public void Add(ParkUser parkUser) {
            _users.Add(parkUser);
        }

        public ParkUser GetBy(string email) {
            return _users.SingleOrDefault(pu => pu.Email == email);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
