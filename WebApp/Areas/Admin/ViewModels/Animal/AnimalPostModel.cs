
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Areas.Admin.ViewModels.Animal
{
    public class AnimalPostModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }
        
        public string Description { get; set; }
        [MaxLength(50)]
        [MinLength(3)]
        public string BinomialName { get; set; }

        public Guid MapSegmentId { get; set; }
        public Guid FeaturedImgId { get; set; }
        public Guid ConservationStatusId { get; set; }
        public Guid ScientificClassificationId { get; set; }
        
    }
}