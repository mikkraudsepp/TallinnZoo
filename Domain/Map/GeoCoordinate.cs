using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Map
{
    public class GeoCoordinate : BaseEntity
    {
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        public DateTime Created { get; set; }
        public Guid MapSegmentId { get; set; }
        public virtual MapSegment MapSegment { get; set; }
    }
}