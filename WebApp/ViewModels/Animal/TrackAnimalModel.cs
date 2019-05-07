using System;
using System.Collections;
using System.Collections.Generic;

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
        public ImageListModel Image { get; set; }
        public MapSegmentModel MapSegment { get; set; }
    }
    
    public class MapSegmentModel
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}