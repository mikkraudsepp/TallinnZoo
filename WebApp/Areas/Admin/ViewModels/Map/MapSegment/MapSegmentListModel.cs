using System;
using System.Collections.Generic;

namespace WebApp.Areas.Admin.ViewModels.Map.MapSegment
{
    public class MapSegmentListModel
    {
        public IEnumerable<MapSegmentItemModel> MapSegments { get; set; } = new List<MapSegmentItemModel>();
    }

    public class MapSegmentItemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}