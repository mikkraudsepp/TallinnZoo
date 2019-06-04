using System;
using System.Collections.Generic;

namespace WebApp.Areas.Admin.ViewModels.SoundTrack
{
    public class IndexModel
    {
        public IEnumerable<SoundTrackListModel> SoundTracks { get; set; } = new List<SoundTrackListModel>();
    }

    public class SoundTrackListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}