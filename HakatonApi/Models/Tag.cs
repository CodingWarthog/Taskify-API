using System;
using System.Collections.Generic;

namespace HakatonApi.Models
{
    public partial class Tag
    {
        public Tag()
        {
            LocationTag = new HashSet<LocationTag>();
        }

        public int IdTag { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<LocationTag> LocationTag { get; set; }
    }
}
