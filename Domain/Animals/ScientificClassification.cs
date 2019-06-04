using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Animals
{
    public class ScientificClassification : BaseEntity
    {
        [Required]
        [MaxLength(80, ErrorMessageResourceName="ErrorMaxLength", ErrorMessageResourceType = typeof(Resources.Texts))]
        [MinLength(3, ErrorMessageResourceName="ErrorMinLength", ErrorMessageResourceType = typeof(Resources.Texts))]
        public string Name { get; set; }
        
        public virtual IList<Animal> Animals { get; set; }
    }
}