using System.Collections.Generic;
using System.Threading.Tasks;
using HakatonApi.Models;
using HakatonApi.Repositories;

namespace HakatonApi.Services
{
    public class LocationService : ILocationService
    {
        private  ILocationRepository _repo;

        public LocationService(ILocationRepository repo)
        {
            _repo = repo;
        }
        
        public async Task<Location> AddLocation(Location location)
        {
         await _repo.AddLocation(location);
          return location;
        }

        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            return await _repo.GetAllLocations();
        }

        public async Task<Location> GetLocation(int id)
        {
            return await _repo.GetLocation(id);
        }

        
        public async Task<IEnumerable<Location>> GetLocationsForUser(int userId)
        {
            return await _repo.GetLocationsForUser(userId);
        }
        
    }
}