using System;
using System.Collections.Generic;

namespace WebApp.Areas.Admin.ViewModels.Animal
{
    public class IndexModel
    {
        public IEnumerable<AnimalListModel> Animals { get; set; } = new List<AnimalListModel>();
    }

    public class AnimalListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}