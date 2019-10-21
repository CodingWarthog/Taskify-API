using HakatonApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonApi.Repositories.GlobalWaitingTaskRepositories
{
    public interface IGlobalTaskRepository
    {
        Task<List<GlobalTaskTag>> GetGlobalTask();
    }
}
