using System;
using System.Collections.Generic;

namespace HakatonApi.Models
{
    public partial class WaitingTask
    {
        public WaitingTask()
        {
            WaitingTaskLocation = new HashSet<WaitingTaskLocation>();
            WaitingTaskTag = new HashSet<WaitingTaskTag>();
        }

        public int IdWaitingTask { get; set; }
        public DateTime? DateAdded { get; set; }
        public string Name { get; set; }
        public string Target { get; set; }
        public int? UserId { get; set; }
        public bool? IsCompleted { get; set; }
        public bool? IsSinglePoint { get; set; }
        public int? Distance { get; set; }
        public DateTime? DateDone { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<WaitingTaskLocation> WaitingTaskLocation { get; set; }
        public virtual ICollection<WaitingTaskTag> WaitingTaskTag { get; set; }
    }
}
