using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Animals
{
    public class AnimalFact : BaseEntity
    {
        [Required]
        [MaxLength(25, ErrorMessageResourceName="ErrorMaxLength", ErrorMessageResourceType = typeof(Resources.Texts))]
        [MinLength(3, ErrorMessageResourceName="ErrorMinLength", ErrorMessageResourceType = typeof(Resources.Texts))]
        public string Label { get; set; }
        [Required]
        public string Description { get; set; }
        public Guid AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}