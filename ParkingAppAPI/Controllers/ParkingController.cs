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
    public class ParkingController : ControllerBase
    {
        private readonly IParkingRepository _parkingRepository;
        private readonly IEntryRepository _entryRepository;

        public ParkingController(IParkingRepository parkingRepository, IEntryRepository entryRepository) {
            _parkingRepository = parkingRepository;
            _entryRepository = entryRepository;
        }

        
        /// <summary>
        /// Get all existing parkings in the database
        /// </summary>
        /// <returns>Array of parkings with their details</returns>
        [HttpGet]
        public IEnumerable<Parking> GetParkings() {
            IEnumerable <Parking> parkings = _parkingRepository.GetAll();
            foreach (var parking in parkings) {
                parking.LatestEntry = _entryRepository.GetLatestEntry(parking.Id);
            }

            return parkings;
        }

       
        /// <summary>
        /// Get the details of a parking with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>parking object</returns>
        [HttpGet("{id}")]
        public ActionResult<Parking> GetParking(int id) {
            Parking parking = _parkingRepository.GetParkingById(id);
            if (parking == null) return NotFound();
            return parking;
        }

    }
}