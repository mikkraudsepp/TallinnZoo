using System;
using System.Collections.Generic;

namespace Domain.Animals
{
    public class ConservationStatus : BaseEntity
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        
        public virtual IList<Animal> Animals { get; set; }
    }
}