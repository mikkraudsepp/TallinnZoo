using System;

namespace Domain.Animals
{
    public class SoundTrackInAnimal : BaseEntity
    {
        public bool IsFeatured { get; set; }

        public  Guid AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
        public Guid SoundTrackId { get; set; }
        public virtual SoundTrack SoundTrack { get; set; }
    }
}