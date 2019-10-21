using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HakatonApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HakatonApi.Repositories
{
    public class LocationRepository : ILocationRepository
    {

        private readonly HackathonWAWContext _context;

        public LocationRepository(HackathonWAWContext context)
        {
            _context = context;
        }
        public async Task<Location> AddLocationInLoop(Location location)
        {
           Location responseLocation= _context.Location.AddAsync(location).Result.Entity;
           
            return responseLocation;
        }

        public async Task<Location> AddLocation(Location location)
        {
           Location responseLocation= _context.Location.AddAsync(location).Result.Entity;
           await _context.SaveChangesAsync();
            return responseLocation;
        }
        


        public async Task<IEnumerable<Location>> GetAllLocations()
        {
           var locations= await _context.Location.ToListAsync();
           return locations;
        }

        public async Task<Location> GetLocation(int id)
        {
            var location= await _context.Location.FirstOrDefaultAsync(x=>x.IdLocation==id);
            return location;
        }

        public async Task<IEnumerable<Location>> GetLocationsForUser(int userId)
        {
            return await _context.Location
                                .Include(wtls=>wtls.WaitingTaskLocation)
                                .ToListAsync();  
        }

        public async void SaveChanges()
        {
          await _context.SaveChangesAsync();
        }
    }
}