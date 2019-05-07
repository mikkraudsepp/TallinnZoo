using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base.EF.Helpers;
using Domain.Animals;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DAL.App.EF.Helpers
{
    public class AppRepositoryFactory : BaseRepositoryFactory
    {
        public AppRepositoryFactory()
        {
            // add to dictionary all the repo creation methods we might need

            RepositoryCreationMethods.Add(typeof(IFeedbackRepository),
                dataContext => new FeedbackRepository(dataContext));

            RepositoryCreationMethods.Add(typeof(IAnimalRepository),
                dataContext => new AnimalRepository(dataContext));

            RepositoryCreationMethods.Add(typeof(IConservationStatusRepository),
                dataContext => new ConservationStatusRepository(dataContext));

            RepositoryCreationMethods.Add(typeof(IAppMapRepository),
                dataContext => new AppMapRepository(dataContext));

            RepositoryCreationMethods.Add(typeof(IMapSegmentRepository),
                dataContext => new MapSegmentRepository(dataContext));

            RepositoryCreationMethods.Add(typeof(IMediaRepository),
                dataContext => new MediaRepository(dataContext));

            RepositoryCreationMethods.Add(typeof(IMediaInAnimalRepository),
                dataContext => new MediaInAnimalRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(ISoundTrackRepository),
                dataContext => new SoundTrackRepository(dataContext));
            
            RepositoryCreationMethods.Add(typeof(ISoundTrackInAnimalRepository),
                dataContext => new SoundTrackInAnimalRepository(dataContext));

            RepositoryCreationMethods.Add(typeof(IAnimalFactRepository),
                dataContext => new AnimalFactRepository(dataContext));
        }
    }
}