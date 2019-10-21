using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HakatonApi.DTOs.AuthDTO;
using HakatonApi.DTOs.LocationDTO;
using HakatonApi.Helpers;
using HakatonApi.Services.GPSServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HakatonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPSController : ControllerBase
    {
        private readonly IGPSService _gpsService;
        private readonly IUserGeter _userGeter;
        public GPSController(IGPSService gpsService, IUserGeter userGeter)
        {
            _gpsService = gpsService;
            _userGeter = userGeter;
        }

        [HttpPost("checkLocations")]
        public async Task<AllTasksInRangeAlertDTO> UserGPSActualization(GPSUserActualizationDTO gpsUserActualizationDTO)
        {
            int userId = _userGeter.GetUser(Request.Headers["Authorization"]);
            var x = await _gpsService.UserGPSActualizationAsync(gpsUserActualizationDTO, userId);

            return x;
        }

    }
}