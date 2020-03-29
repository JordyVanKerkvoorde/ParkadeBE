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
    public class EntryController : ControllerBase
    {
        private readonly IParkingRepository _parkingRepository;
        private readonly IEntryRepository _entryRepository;

        public EntryController(IParkingRepository parkingRepository, IEntryRepository entryRepository) {
            _parkingRepository = parkingRepository;
            _entryRepository = entryRepository;
        }

        
        /// <summary>
        /// Get the latest entry of a parking with given id
        /// </summary>
        /// <param name="parkingId"></param>
        /// <returns>entry object</returns>
        [HttpGet("{parkingId}")]
        public ActionResult<Entry> GetLatestEntry(int parkingId) {
            return _entryRepository.GetLatestEntry(parkingId);
        }
    }
}