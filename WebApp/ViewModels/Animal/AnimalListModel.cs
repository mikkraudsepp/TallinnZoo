using System;
using System.Collections;
using System.Collections.Generic;
using WebApp.ViewModels.Media;

namespace WebApp.ViewModels.Animal
{
    public class AnimalListModel
    {
        public IEnumerable<AnimalItemModel> Animals { get; set; } = new List<AnimalItemModel>();
    }

    public class AnimalItemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ImageModel Image { get; set; }
    }
}