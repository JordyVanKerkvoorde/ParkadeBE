using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingAppAPI.Models;

namespace ParkingAppAPI.Data.Mappers {
    public class ParkingConfiguration : IEntityTypeConfiguration<Parking> {
        public void Configure(EntityTypeBuilder<Parking> builder) {
            builder.ToTable("Parking");
            builder.HasKey(t => t.Id);
        }
    }
}
