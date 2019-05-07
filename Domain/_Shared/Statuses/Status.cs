using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain._Shared.Statuses
{
    public class Status : BaseEntity
    {
        
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; }

        public virtual IList<StatusInMapSegment> StatusInMapSegments { get; set; }
    }
}