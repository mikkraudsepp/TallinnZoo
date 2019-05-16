using System;
using System.Collections;
using System.Collections.Generic;
using WebApp.ViewModels.Media;

namespace WebApp.ViewModels.Animal
{
    public class TrackAnimalModel
    {
        public IEnumerable<TrackAnimalListModel> Animals { get; set; } = new List<TrackAnimalListModel>();
    }

    public class TrackAnimalListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double DistanceFromUser { get; set; }
        public ImageModel Image { get; set; }
        public MapSegmentModel MapSegment { get; set; }
    }
    
    public class MapSegmentModel
    {
        public string Name { get; set; }
        public List<GeoCoordinateModel> GeoCoordinates { get; set; } = new List<GeoCoordinateModel>();

    }

    public class GeoCoordinateModel
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}