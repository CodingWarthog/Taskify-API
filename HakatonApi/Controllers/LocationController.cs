using System.Collections.Generic;
using System.Threading.Tasks;
using HakatonApi.Models;
using HakatonApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HakatonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _service;
        public LocationController(ILocationService service)
        {
           _service = service;
        }

        [HttpGet]
        public Task<IEnumerable<Location>> Get(){
            System.Console.WriteLine("Get locations");
            return _service.GetAllLocations();
        }
        [HttpGet("{id}")]
        public Task<IEnumerable<Location>> GetUserLocations(int id){
            return _service.GetLocationsForUser(id);
        }
    }
}