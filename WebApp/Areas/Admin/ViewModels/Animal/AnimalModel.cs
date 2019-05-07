using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels.Animal
{
    public class AnimalModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BinomialName { get; set; }
        public virtual ImageModel FeaturedImage { get; set; }
        public ConservationStatusModel ConservationStatus { get; set; }
        public Guid? ConservationStatusId { get; set; }
        public IList<SelectListItem> ConservationStatuses { get; set; }
    }
    
    public class ImageModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class ConservationStatusModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}