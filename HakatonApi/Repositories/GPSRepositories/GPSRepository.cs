using HakatonApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonApi.Repositories.GPSRepositories
{
    public class GPSRepository : IGPSRepository
    {
        private readonly HackathonWAWContext _context;

        public GPSRepository(HackathonWAWContext context)
        {
            _context = context;

        }

        public async Task<List<WaitingTaskLocation>> GetUserTaskLocationsAsync(int idUser)
        {
            
            return await _context.WaitingTaskLocation
                .Include(waitingTask => waitingTask.WaitingTask)
                .Include(location => location.Location)
                .Where(x => x.WaitingTask.UserId == idUser && 
                       x.WaitingTask.IsCompleted == false &&
                       x.WaitingTask.IsDeleted == false)
                .ToListAsync();
        }
    }
}
