using HakatonApi.DTOs.GlobalTaskDTO;
using HakatonApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonApi.Services.GlobalTaskServices
{
    public interface IGlobalTaskService
    {
        Task<List<GlobalTaskToDisplayDTO>> GetGlobalTaskForTodayAsync();
    }
}
