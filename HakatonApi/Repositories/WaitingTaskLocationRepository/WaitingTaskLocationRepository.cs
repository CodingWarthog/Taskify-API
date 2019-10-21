using System.Threading.Tasks;
using HakatonApi.Models;

namespace HakatonApi.Repositories.WaitingTaskLocationRepository
{
    public class WaitingTaskLocationRepository : IWaitingTaskLocationRepository
    {
        private readonly HackathonWAWContext _context;

        public WaitingTaskLocationRepository(HackathonWAWContext context)
        {
            _context = context;
        }
        public async Task<WaitingTaskLocation> AddWaitingTaskLocationInLoop(WaitingTaskLocation waitingTaskLocation)
        {
           WaitingTaskLocation waitingTaskLocationResponse = _context.WaitingTaskLocation.AddAsync(waitingTaskLocation).Result.Entity;
           
            return waitingTaskLocationResponse;
        }
        public async Task<WaitingTaskLocation> AddWaitingTaskLocation(WaitingTaskLocation waitingTaskLocation)
        {
           WaitingTaskLocation waitingTaskLocationResponse = _context.WaitingTaskLocation.AddAsync(waitingTaskLocation).Result.Entity;
            await _context.SaveChangesAsync();
            return waitingTaskLocationResponse;
        }

        public async void SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}