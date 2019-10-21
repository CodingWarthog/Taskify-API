using System;

namespace HakatonApi.DTOs.WaitingTaskDTO
{
    public class WaitingTaskForListDisplayDTO
    {
        
        public DateTime? DateAdded { get; set; }
        public string Name { get; set; }
        public string Target { get; set; }
      
        public int? Distance { get; set; }
        public DateTime? DateDone { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? IsCompleted { get; set; }


    }
}