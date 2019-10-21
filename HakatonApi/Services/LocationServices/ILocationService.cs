using System.Collections.Generic;
using System.Threading.Tasks;
using HakatonApi.Models;

namespace HakatonApi.Services
{
    public interface ILocationService
    {
        Task<Location> AddLocation(Location location);
        Task<Location> GetLocation(int id);
        Task<IEnumerable<Location>>  GetLocationsForUser(int userId);
        Task<IEnumerable<Location>> GetAllLocations();
    }
}