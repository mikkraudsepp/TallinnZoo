using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Animals
{
    public class AnimalFact : BaseEntity
    {
        [Required]
        public string Label { get; set; }
        [Required]
        public string Description { get; set; }
        public Guid AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}