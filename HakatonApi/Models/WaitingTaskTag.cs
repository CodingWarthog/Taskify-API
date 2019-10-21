using System;
using System.Collections.Generic;

namespace HakatonApi.Models
{
    public partial class WaitingTaskTag
    {
        public int IdWaitingTaskTag { get; set; }
        public int? WaitingTaskId { get; set; }
        public int? TaskTagId { get; set; }

        public virtual TaskTag TaskTag { get; set; }
        public virtual WaitingTask WaitingTask { get; set; }
    }
}
