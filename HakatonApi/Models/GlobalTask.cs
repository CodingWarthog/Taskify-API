using System;
using System.Collections.Generic;

namespace HakatonApi.Models
{
    public partial class GlobalTask
    {
        public GlobalTask()
        {
            GlobalTaskTag = new HashSet<GlobalTaskTag>();
        }

        public int IdGlobalTask { get; set; }
        public string GlobalTaskName { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
        public string GlobalTaskDescription { get; set; }
        public DateTime? GlobalTaskDate { get; set; }

        public virtual ICollection<GlobalTaskTag> GlobalTaskTag { get; set; }
    }
}
