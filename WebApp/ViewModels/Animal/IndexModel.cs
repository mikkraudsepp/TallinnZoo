using System;
using System.Collections;
using System.Collections.Generic;

namespace WebApp.ViewModels.Animal
{
    public class IndexModel
    {
        public IEnumerable<AnimalListModel> Animals { get; set; } = new List<AnimalListModel>();
    }

    public class AnimalListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ImageListModel Image { get; set; }
    }

    public class ImageListModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}