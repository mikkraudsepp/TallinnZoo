using System;

namespace Domain.Animals
{
    public class MediaInAnimal : BaseEntity
    {

        public Guid AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
        public Guid MediaId { get; set; }
        public virtual Media Media { get; set; }
    }
}