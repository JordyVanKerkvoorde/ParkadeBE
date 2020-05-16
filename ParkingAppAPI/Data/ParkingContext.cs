using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingAppAPI.Models;

namespace ParkingAppAPI.Data {
    public class ParkingContext : IdentityDbContext {
        public DbSet<Parking> Parking { get; set; }
        public DbSet<Entry> Entry { get; set; }
        public DbSet<Suggestion> Suggestion { get; set; }
        public DbSet<ParkUser> ParkUser { get; set; }

        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options) {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            var connectionString = @"Server=178.62.218.13,1433;Database=ParkingsDB;User Id=SA;Password=Admin20204Parkade763325;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}
