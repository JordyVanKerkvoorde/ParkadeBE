using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAppAPI.Models {
    public interface IParkUserRepository {
        ParkUser GetBy(string email);
        void Add(ParkUser parkUser);
        void SaveChanges();
    }
}
