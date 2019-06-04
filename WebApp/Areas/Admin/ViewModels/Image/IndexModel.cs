using System;
using System.Collections.Generic;

namespace WebApp.Areas.Admin.ViewModels.Image
{
    public class IndexModel
    {
        public IEnumerable<ImageListModel> Images { get; set; } = new List<ImageListModel>();
    }

    public class ImageListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}