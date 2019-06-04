using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Animals;

namespace Domain.Map
{
    public class MapSegment : BaseEntity
    {
        public Guid NameId { get; set; }
        [Required]
        [MaxLength(80, ErrorMessageResourceName="ErrorMaxLength", ErrorMessageResourceType = typeof(Resources.Texts))]
        [MinLength(3, ErrorMessageResourceName="ErrorMinLength", ErrorMessageResourceType = typeof(Resources.Texts))]
        public virtual MultiLangString Name { get; set; }
        public Guid? AppMapId { get; set; }
        public virtual AppMap AppMap { get; set; }
        public Guid? AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual IList<GeoCoordinate> GeoCoordinates { get; set; }
    }
}