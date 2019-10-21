using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HakatonApi.Helpers;
using HakatonApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HakatonApi.Repositories.WaitingTaskRepository
{
    public class WaitingTaskRepository : IWaitingTaskRepository
    {
        private readonly HackathonWAWContext _context;
        private readonly IUserGeter _userGeter;

        public WaitingTaskRepository(HackathonWAWContext context, IUserGeter userGeter)
        {        
            _context = context;
            _userGeter = userGeter;        
        }

        public async Task<WaitingTask> AddWaitingTask(WaitingTask waitingTask)
        {
             WaitingTask responseWaitingTask= _context.WaitingTask.AddAsync(waitingTask).Result.Entity;
            await _context.SaveChangesAsync();
            return responseWaitingTask;

        }

        public async Task<IEnumerable<WaitingTask>> GetUsersWaitingTask(int idUser)
        {
            var waitingTasksLocation = await _context.WaitingTask
               .Where(x => x.UserId == idUser && x.IsDeleted == false)
               .ToListAsync();

            return waitingTasksLocation;
        }

        public async Task<IEnumerable<WaitingTask>> GetCompletedUsersWaitingTask(int idUser)
        {
            var waitingTasksLocation = await _context.WaitingTask
               .Where(x => x.UserId == idUser)
                .Where(y => y.IsCompleted == true && y.IsDeleted == false)
               .ToListAsync();

            return waitingTasksLocation;
        }

        public async Task<IEnumerable<WaitingTask>> GetActiveUsersWaitingTask(int idUser)
        {
            var waitingTasksLocation = await _context.WaitingTask
               .Where(x => x.UserId == idUser)
               .Where(y => y.IsCompleted == false && y.IsDeleted == false)
               .ToListAsync();

            return waitingTasksLocation;
        }

        public async Task<WaitingTask> CompleteWaitingTask(string waitingTaskName,int userId)
        {
            WaitingTask completedWaitingTask = await _context.WaitingTask
                                            .FirstOrDefaultAsync(x => x.Name == waitingTaskName && x.UserId==userId);
            completedWaitingTask.IsCompleted = true;
            _context.WaitingTask.Update(completedWaitingTask);
            await _context.SaveChangesAsync();
            return completedWaitingTask;
        }

        public async Task<int> SetWaitingTaskAsDeletedAsync(string waitingTaskName, int userId)
        {
            var waitingTask = await _context.WaitingTask
                     .Where(w => w.Name == waitingTaskName && w.UserId == userId)
                     .FirstOrDefaultAsync();

            waitingTask.IsDeleted = true;

            _context.Entry(waitingTask).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public Task<bool> Contain(string waitingTaskName,int userId)
        {
            return _context.WaitingTask.AnyAsync(x=>x.Name==waitingTaskName && x.UserId==userId && x.IsCompleted==false && x.IsDeleted==false);
        }
    }
}