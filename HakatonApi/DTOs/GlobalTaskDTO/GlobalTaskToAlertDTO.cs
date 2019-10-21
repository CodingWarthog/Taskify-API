using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonApi.DTOs.GlobalTaskDTO
{
    public class GlobalTaskToAlertDTO
    {
        public string GlobalTaskName { get; set; }    
        public string Latitude { get; set; }
        public string Longtitude { get; set; }
        public string GlobalTaskDescription { get; set; }
        public DateTime? GlobalTaskDate { get; set; }
        public string GlobalTagName { get; set; }
        public double DistanceFromUser { get; set; }
    }
}
