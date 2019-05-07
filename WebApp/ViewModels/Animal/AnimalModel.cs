using System;
using System.Collections.Generic;

namespace WebApp.ViewModels.Animal
       {
           public class AnimalModel
           {
               public Guid Id { get; set; }
               public string Name { get; set; }
               public string Description { get; set; }
               public string BinomialName { get; set; }
               public ImageModel FeaturedImage { get; set; }
               public MapSegmentModel MapSegment { get; set; }
               public List<SoundTrackModel> AnimalSoundTracks { get; set; } = new List<SoundTrackModel>();
               public List<ImageModel> AnimalPictures { get; set; } = new List<ImageModel>();
                public IEnumerable<FactModel> Facts { get; set; }
           }
           
           
           public class ImageModel
           {
               public string Name { get; set; }
               public string Url { get; set; }
           }

           public class SoundTrackModel
           {
               public string Name { get; set; }
               public string Url { get; set; }
           }
           
           public class FactModel
           {
               public string Label { get; set; }
               public string Description { get; set; }
           }
       }