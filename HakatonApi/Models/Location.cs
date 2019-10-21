using System;
using System.Collections.Generic;

namespace HakatonApi.Models
{
    public partial class Location
    {
        public Location()
        {
            LocationTag = new HashSet<LocationTag>();
            WaitingTaskLocation = new HashSet<WaitingTaskLocation>();
        }

        public int IdLocation { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }

        public virtual ICollection<LocationTag> LocationTag { get; set; }
        public virtual ICollection<WaitingTaskLocation> WaitingTaskLocation { get; set; }
    }
}
