using System;
using System.Collections.Generic;

namespace WebApp.Areas.Admin.ViewModels.Animal
{
    public class IndexModel
    {
        public IEnumerable<AnimalItemModel> Animals { get; set; } = new List<AnimalItemModel>();
    }

    public class AnimalItemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}