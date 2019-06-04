using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain._Shared.Statuses
{
    public class Status : BaseEntity
    {
        
        [Required]
        [MaxLength(20, ErrorMessageResourceName="ErrorMaxLength", ErrorMessageResourceType = typeof(Resources.Texts))]
        [MinLength(3, ErrorMessageResourceName="ErrorMinLength", ErrorMessageResourceType = typeof(Resources.Texts))]
        public string Name { get; set; }

        public virtual IList<StatusInMapSegment> StatusInMapSegments { get; set; }
    }
}