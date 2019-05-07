using System;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base;

namespace Contracts.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        IAnimalService Animals { get; }
        IFeedbackService Feedbacks { get; }
        IConservationStatusService ConservationStatuses { get; }
        IAppMapService AppMaps { get; }
        IMapSegmentService MapSegments { get; }

        IMediaService Medias { get; }
        IMediaInAnimalService MediaInAnimals { get; }
        ISoundTrackService SoundTracks { get; }
        ISoundTrackInAnimalService SoundTrackInAnimals { get; }
        IAnimalFactService AnimalFacts { get; }
    }
}
