using System;
using System.Collections.Generic;

namespace HakatonApi.Models
{
    public partial class WaitingTaskLocation
    {
        public int IdWaitingTaskLocation { get; set; }
        public int? WaitingTaskId { get; set; }
        public int? LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual WaitingTask WaitingTask { get; set; }
    }
}
