using System;
using System.Collections.Generic;
using Domain.Animals;

namespace Domain._Shared.Statuses
{
    public class StatusInMapSegment : BaseEntity
    {
        public DateTime? ActiveDateTimeFrom { get; set; }
        public DateTime? ActiveDateTimeTo { get; set; }
        public bool IsActive { get; set; }

        public Guid MapSegmentId { get; set; }
        public virtual Animal MapSegment { get; set; }
        public Guid StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}