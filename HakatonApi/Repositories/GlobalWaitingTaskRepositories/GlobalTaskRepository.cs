using HakatonApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonApi.Repositories.GlobalWaitingTaskRepositories
{
    public class GlobalTaskRepository : IGlobalTaskRepository
    {
        private readonly HackathonWAWContext _context;

        public GlobalTaskRepository(HackathonWAWContext context)
        {
            _context = context;
        }

        public async Task<List<GlobalTaskTag>> GetGlobalTask()
        {
            return await _context.GlobalTaskTag
                .Include(globalTask => globalTask.GlobalTask)
                .Include(globalTag => globalTag.GlobalTag)
                .ToListAsync();
        }
    }
}
