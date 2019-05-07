using System;
using System.Collections.Generic;

namespace Domain.Animals
{
    public class ScientificClassification : BaseEntity
    {
        public string Name { get; set; }
        
        public virtual IList<Animal> Animals { get; set; }
    }
}