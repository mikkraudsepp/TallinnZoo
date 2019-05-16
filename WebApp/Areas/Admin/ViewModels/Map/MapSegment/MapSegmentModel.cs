using System;
using System.Collections.Generic;

namespace WebApp.Areas.Admin.ViewModels.Map.MapSegment
{
    public class MapSegmentModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<GeoCoordinateModel> GeoCoordinates { get; set; } = new List<GeoCoordinateModel>();

    }

    public class GeoCoordinateModel
    {
        public Guid Id { get; set; }
        public string MapSegmentName { get; set; }

        public Guid MapSegmentId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}