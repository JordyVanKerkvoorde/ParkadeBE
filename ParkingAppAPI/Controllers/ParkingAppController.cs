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

        public ParkingAppController() {

        }

        public IEnumerable<Parking> GetParkings() {
            throw new NotSupportedException();
        }
    }
}