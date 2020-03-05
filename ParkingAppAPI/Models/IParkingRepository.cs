using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAppAPI.Models {
    public interface IParkingRepository {
        IEnumerable<Parking> GetAll();
        Parking GetParkingById(int id);
        void AddParking(Parking parking);
        void DeleteParking(Parking parking);
        void UpdateParking(Parking parking);
        void SaveChanges();
    }
}
