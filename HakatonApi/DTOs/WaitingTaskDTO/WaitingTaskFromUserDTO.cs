using System;

namespace HakatonApi.DTOs.WaitingTaskDTO
{
    public class WaitingTaskFromUserDTO
    {
        
        public string Name { get; set; }
        public string Target{get;set;}
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}