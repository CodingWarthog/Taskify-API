using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonApi.DTOs.LocationDTO
{
    public class WaitingTaskInRangeAlertDTO
    {
        public DateTime DateAdded { get; set; }
        public string WaitingTaskName { get; set; }
        public string Target { get; set; }
        public int DistanceWhenAlert {get;set;}
        public DateTime DateEnd { get; set; }
        public double DistanceFromUserToLocation {get;set;}
        public string LocationName { get; set; }
        public string LocationType { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        

    }
}
