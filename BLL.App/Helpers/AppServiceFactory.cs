using BLL.App.Services;
using BLL.Base.Helpers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Helpers
{
    public class AppServiceFactory : BaseServiceFactory<IAppUnitOfWork>
    {
        public AppServiceFactory()
        {
            RegisterAllCreationMethods();
        }

        private void RegisterAllCreationMethods()
        {
            AddCreationMethod<IAnimalService>(uow => new AnimalService(uow));
            AddCreationMethod<IFeedbackService>(uow => new FeedbackService(uow));
            AddCreationMethod<IConservationStatusService>(uow => new ConservationStatusService(uow));
            AddCreationMethod<IAppMapService>(uow => new AppMapService(uow));
            AddCreationMethod<IMapSegmentService>(uow => new MapSegmentService(uow));
            AddCreationMethod<IGeoCoordinateService>(uow => new GeoCoordinateService(uow));
            AddCreationMethod<IMediaService>(uow => new MediaService(uow));
            AddCreationMethod<ISoundTrackService>(uow => new SoundTrackService(uow));
            AddCreationMethod<IMediaInAnimalService>(uow => new MediaInAnimalService(uow));
            AddCreationMethod<ISoundTrackInAnimalService>(uow => new SoundTrackInAnimalService(uow));
            AddCreationMethod<IAnimalFactService>(uow => new AnimalFactService(uow));
        }
    }
}
