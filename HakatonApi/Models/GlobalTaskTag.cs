using System;
using System.Collections.Generic;

namespace HakatonApi.Models
{
    public partial class GlobalTaskTag
    {
        public int IdGlobalTaskGlobalTag { get; set; }
        public int? GlobalTaskId { get; set; }
        public int? GlobalTagId { get; set; }

        public virtual GlobalTag GlobalTag { get; set; }
        public virtual GlobalTask GlobalTask { get; set; }
    }
}
