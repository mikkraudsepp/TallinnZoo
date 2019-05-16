using System;
using System.Collections.Generic;
using Domain.Animals;

namespace Domain.Map
{
    public class MapSegment : BaseEntity
    {
        public string Name { get; set; }
        public Guid? AppMapId { get; set; }
        public virtual AppMap AppMap { get; set; }
        public Guid? AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual IList<GeoCoordinate> GeoCoordinates { get; set; }
    }
}