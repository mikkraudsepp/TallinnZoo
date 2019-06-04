using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Map;
using Domain._Shared;
using Domain._Shared.Statuses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Animals
{
    public class Animal : BaseEntity
    {
        public Animal()
        {
            Created = DateTime.Now;
        }
        
        public Guid NameId { get; set; }
        [Required]
        [MaxLength(80, ErrorMessageResourceName="ErrorMaxLength", ErrorMessageResourceType = typeof(Resources.Texts))]
        [MinLength(3, ErrorMessageResourceName="ErrorMinLength", ErrorMessageResourceType = typeof(Resources.Texts))]
        public virtual MultiLangString Name { get; set; }
        public Guid? DescriptionId { get; set; }
        public virtual MultiLangString Description { get; set; }
        public string BinomialName { get; set; }
        public DateTime LastEdited { get; set; }
        public DateTime Created { get; set; }

        public Guid? MapSegmentId { get; set; }
        public virtual MapSegment MapSegment { get; set; }
        public Guid? FeaturedImgId { get; set; }
        public virtual Media FeaturedImg { get; set; }
        public Guid? ConservationStatusId { get; set; }
        public virtual ConservationStatus ConservationStatus { get; set; }
        public Guid? ScientificClassificationId { get; set; }
        public virtual ScientificClassification ScientificClassification { get; set; }
        public virtual IList<AnimalFact> AnimalFacts { get; set; }
        public virtual IList<MediaInAnimal> MediaInAnimals { get; set; }
        public virtual IList<SoundTrackInAnimal> AnimalSoundTracks { get; set; }
    }
}