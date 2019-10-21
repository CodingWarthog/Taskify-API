using HakatonApi.DTOs.GlobalTaskDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonApi.DTOs.LocationDTO
{
    public class AllTasksInRangeAlertDTO
    {
        public List<GlobalTaskToAlertDTO> globalTasksInRange { get; set; }
        public List<WaitingTaskInRangeAlertDTO> userWaitingTaskInRange { get; set; }
    }
}
