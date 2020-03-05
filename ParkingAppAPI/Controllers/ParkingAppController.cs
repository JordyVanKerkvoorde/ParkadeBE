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
            foreach (var parking in _parkingRepository.GetAll()) {
                parking.AddRandomEntry();
                _parkingRepository.SaveChanges();
            }
            return _parkingRepository.GetAll();
        }
    }
}