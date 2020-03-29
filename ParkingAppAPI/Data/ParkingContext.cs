using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingAppAPI.Models;

namespace ParkingAppAPI.Data {
    public class ParkingContext : DbContext {
        public DbSet<Parking> Parking { get; set; }
        public DbSet<Entry> Entry { get; set; }

        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options) {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //via externe server
            var connectionString = @"Server=xxxxx;Database=Parkings;User Id=xxxxx;Password=xxxxx;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}
