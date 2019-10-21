using System;
using System.Collections.Generic;

namespace HakatonApi.Models
{
    public partial class LocationTag
    {
        public int IdLocationTag { get; set; }
        public int? TagId { get; set; }
        public int? LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
