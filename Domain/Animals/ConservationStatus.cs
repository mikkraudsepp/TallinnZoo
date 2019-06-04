using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Animals
{
    public class ConservationStatus : BaseEntity
    {
        public Guid NameId { get; set; }
        [Required]
        [MaxLength(80, ErrorMessageResourceName="ErrorMaxLength", ErrorMessageResourceType = typeof(Resources.Texts))]
        [MinLength(3, ErrorMessageResourceName="ErrorMinLength", ErrorMessageResourceType = typeof(Resources.Texts))]
        public virtual MultiLangString Name { get; set; }
        public string Abbreviation { get; set; }
        
        public virtual IList<Animal> Animals { get; set; }
    }
}