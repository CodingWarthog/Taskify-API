using HakatonApi.DTOs.AuthDTO;
using HakatonApi.DTOs.LocationDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonApi.Services.GPSServices
{
    public interface IGPSService 
    {
        //Task<IActionResult> UserGPSActualizationAsync(GPSUserActualizationDTO gpsUserActualizationDTO);
        Task<AllTasksInRangeAlertDTO> UserGPSActualizationAsync(GPSUserActualizationDTO gpsUserActualizationDTO, int userId);
    }
}
