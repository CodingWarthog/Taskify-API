using HakatonApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonApi.Repositories.TaskTagRepositories
{
    public class TaskTagRepository : ITaskTagRepository
    {
        private readonly HackathonWAWContext _context;

        public TaskTagRepository(HackathonWAWContext context)
        {
            _context = context;
        }

        public async Task<List<TaskTag>> GetAllTaskTagsAsync()
        {
            return await _context.TaskTag.ToListAsync();
        }

    }
}
