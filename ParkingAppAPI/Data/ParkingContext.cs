using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingAppAPI.Data.Mappers;
using ParkingAppAPI.Models;

namespace ParkingAppAPI.Data {
    public class ParkingContext : DbContext {
        public DbSet<Parking> Parkings { get; set; }
        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options) {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            var connectionString = @"Server=.;Database=Parkings;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ParkingConfiguration());
        }
    }
}
