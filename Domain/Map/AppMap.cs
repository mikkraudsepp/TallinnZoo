using System;
using System.Collections.Generic;

namespace Domain.Map
{
    public class AppMap : BaseEntity
    {
        public string Name { get; set; }

        public virtual IList<MapSegment> MapSegments { get; set; }
    }
}