using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonApi.DTOs.LocationDTO
{
    public class LocationDTO
    {
        
        public string LocationName { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
        public int Distance { get; set; }
    }
}
