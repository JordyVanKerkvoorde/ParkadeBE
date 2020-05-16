using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingAppAPI.DTO;
using ParkingAppAPI.Models;

namespace ParkingAppAPI.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ParkUserController : ControllerBase {
        private readonly IParkUserRepository _parkUserRepository;
        public ParkUserController(IParkUserRepository parkUserRepository) {
            _parkUserRepository = parkUserRepository;
        }

        /// <summary>
        /// Get the details of the authenticated user
        /// </summary>
        /// <returns>the parkuser</returns>
        [HttpGet()]
        public ActionResult<ParkUserDTO> GetParkUser() {
            ParkUser user = _parkUserRepository.GetBy(User.Identity.Name);
            return new ParkUserDTO(user);
        }
    }
}