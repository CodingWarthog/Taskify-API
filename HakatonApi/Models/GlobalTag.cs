using System;
using System.Collections.Generic;

namespace HakatonApi.Models
{
    public partial class GlobalTag
    {
        public GlobalTag()
        {
            GlobalTaskTag = new HashSet<GlobalTaskTag>();
        }

        public int IdGlobalTag { get; set; }
        public string GlobalTagName { get; set; }

        public virtual ICollection<GlobalTaskTag> GlobalTaskTag { get; set; }
    }
}
