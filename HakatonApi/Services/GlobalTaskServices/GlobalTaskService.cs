using AutoMapper;
using HakatonApi.DTOs.GlobalTaskDTO;
using HakatonApi.Models;
using HakatonApi.Repositories.GlobalWaitingTaskRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonApi.Services.GlobalTaskServices
{
    public class GlobalTaskService : IGlobalTaskService
    {
        private readonly IGlobalTaskRepository _repo;
        private readonly IMapper _mapper;
       
        public GlobalTaskService(IGlobalTaskRepository repo, IMapService mapService, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<GlobalTaskToDisplayDTO>> GetGlobalTaskForTodayAsync()
        {
            var globalTasks = await _repo.GetGlobalTask();
            List<GlobalTaskToDisplayDTO> listToRet = new List<GlobalTaskToDisplayDTO>();
            DateTime today = DateTime.Now;

            if (globalTasks.Count > 0)
            {
                for(int i = 0; i< globalTasks.Count; i++)
                {
                    int day = globalTasks[i].GlobalTask.GlobalTaskDate.Value.Day;
                    int month = globalTasks[i].GlobalTask.GlobalTaskDate.Value.Month;
                    int year = globalTasks[i].GlobalTask.GlobalTaskDate.Value.Year;

                    if (day== today.Day && month == today.Month && year == today.Year)
                    {
                        var globTask = _mapper.Map<GlobalTaskToDisplayDTO>(globalTasks[i]);
                        listToRet.Add(globTask);
                    }
                }
            }
            
            return listToRet;
        }
    }
}
