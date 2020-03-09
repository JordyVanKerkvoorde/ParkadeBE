using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingAppAPI.Models;

namespace ParkingAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingAppController : ControllerBase
    {
        private readonly IParkingRepository _parkingRepository;

        public ParkingAppController(IParkingRepository parkingRepository) {
            _parkingRepository = parkingRepository;
        }

        [HttpGet]
        public IEnumerable<Parking> GetParkings() {
            return _parkingRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Parking> GetParking(int id) {
            Parking parking = _parkingRepository.GetParkingById(id);
            if (parking == null) return NotFound();
            return parking;
        }

        [HttpPost]
        public ActionResult<Parking> PostParking(int id, string name, double? latitude, double? longtitude, int maxcap, int available, string type) {
            DateTime now = DateTime.Now;
            //onderstaande check veranderen door te zoeken op id en op naam => nieuwe repo method + IRepo method
            Parking newParking;
            if (_parkingRepository.GetParkingById(id) == null) {
                if (type == "bike") {
                    newParking = new Parking(id, name, maxcap, type);
                } else {
                    newParking = new Parking(id, name, maxcap, type);
                    newParking.Latitude = latitude;
                    newParking.Longtitude = longtitude;
                }
                Entry entryToCreate = new Entry(now, available);
                newParking.AddEntry(entryToCreate);
                _parkingRepository.AddParking(newParking);
                _parkingRepository.SaveChanges();
            } else {
                newParking = _parkingRepository.GetParkingById(id);
                newParking.AddEntry(new Entry(now, available));
                _parkingRepository.UpdateParking(newParking);
                _parkingRepository.SaveChanges();
            }
            
            return CreatedAtAction(nameof(GetParking), new { id = newParking.Id }, newParking);
        }
    }
}