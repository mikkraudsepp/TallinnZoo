using System;
using System.Collections.Generic;
using Domain.Animals;
using Domain.Identity;

namespace Domain
{
    public class Media : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime UploadedDateTime { get; set; }
        public string FileType { get; set; }
        public Guid UploaderUserId { get; set; }
        public virtual AppUser UploaderUser { get; set; }
        public virtual IList<Animal> Animals { get; set; }
        public virtual IList<MediaInAnimal> MediaInAnimals { get; set; }
    }
}