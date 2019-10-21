using System;
using System.Collections.Generic;

namespace HakatonApi.Models
{
    public partial class TaskTag
    {
        public TaskTag()
        {
            WaitingTaskTag = new HashSet<WaitingTaskTag>();
        }

        public int IdTaskTag { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<WaitingTaskTag> WaitingTaskTag { get; set; }
    }
}
