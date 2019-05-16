using System;
using System.Collections.Generic;

namespace Domain.Map
{
    public class GeoCoordinate : BaseEntity
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime Created { get; set; }
        public Guid MapSegmentId { get; set; }
        public virtual MapSegment MapSegment { get; set; }
    }
}