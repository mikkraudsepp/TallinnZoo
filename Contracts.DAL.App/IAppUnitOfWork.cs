using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;

namespace Contracts.DAL.App
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        IFeedbackRepository Feedbacks { get; }
        IAnimalRepository Animals { get; }
        IConservationStatusRepository ConservationStatuses { get; }
        IAppMapRepository AppMaps { get; }
        IMapSegmentRepository MapSegments { get; }
        IGeoCoordinateRepository GeoCoordinates { get; }
        IMediaRepository Medias { get; }
        IMediaInAnimalRepository MediaInAnimals { get; }
        ISoundTrackRepository SoundTracks { get; }
        ISoundTrackInAnimalRepository SoundTrackInAnimals { get; }
        IAnimalFactRepository AnimalFacts { get; }
    }
}