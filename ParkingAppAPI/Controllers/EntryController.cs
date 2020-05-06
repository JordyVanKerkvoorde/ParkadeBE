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
        /// Returns a dataset of entrys for a given parkingid with the entrys for that day
        /// </summary>
        /// <param name="parkingId"></param>
        /// <returns>entry object</returns>
        [HttpGet("{parkingId}")]
        public ActionResult<DataWrapper> GetTodaysChartData(int parkingId) {
            return _entryRepository.todayChartData(parkingId);
        }
    }
}