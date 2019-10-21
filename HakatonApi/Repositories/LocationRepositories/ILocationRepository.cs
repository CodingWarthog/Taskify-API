using System.Collections.Generic;
using System.Threading.Tasks;
using HakatonApi.Models;

namespace HakatonApi.Repositories
{
    public interface ILocationRepository
    {
        Task<Location> AddLocationInLoop(Location location);
        Task<Location> AddLocation(Location location);
        void SaveChanges();
        Task<Location> GetLocation(int id);
        
        Task<IEnumerable<Location>>  GetLocationsForUser(int userId);
        Task<IEnumerable<Location>> GetAllLocations();
        

    }
}