using System;
using System.Threading.Tasks;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using Contracts.DAL.Base.Helpers;
using Contracts.DAL.Base.Repositories;

namespace DAL.App.EF
{
    public class AppUnitOfWork : IAppUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly IRepositoryProvider _repositoryProvider;

        public IAnimalRepository Animals =>
            _repositoryProvider.GetRepository<IAnimalRepository>();

        public IFeedbackRepository Feedbacks =>
            _repositoryProvider.GetRepository<IFeedbackRepository>();
        
        public IConservationStatusRepository ConservationStatuses =>
            _repositoryProvider.GetRepository<IConservationStatusRepository>();
        
        public IAppMapRepository AppMaps =>
            _repositoryProvider.GetRepository<IAppMapRepository>();

        public IMapSegmentRepository MapSegments =>
            _repositoryProvider.GetRepository<IMapSegmentRepository>();
        
        public IMediaRepository Medias =>
            _repositoryProvider.GetRepository<IMediaRepository>();
        
        public IMediaInAnimalRepository MediaInAnimals =>
            _repositoryProvider.GetRepository<IMediaInAnimalRepository>();
        
        public ISoundTrackRepository SoundTracks =>
            _repositoryProvider.GetRepository<ISoundTrackRepository>();
        
        public ISoundTrackInAnimalRepository SoundTrackInAnimals =>
            _repositoryProvider.GetRepository<ISoundTrackInAnimalRepository>();
        
        public IAnimalFactRepository AnimalFacts =>
            _repositoryProvider.GetRepository<IAnimalFactRepository>();

        public IBaseRepositoryAsync<TEntity> BaseRepository<TEntity>() where TEntity : class, IBaseEntity, new() =>
            _repositoryProvider.GetRepositoryForEntity<TEntity>();

        public AppUnitOfWork(IDataContext dataContext, IRepositoryProvider repositoryProvider)
        {
            _appDbContext = (dataContext as AppDbContext) ?? throw new ArgumentNullException(nameof(dataContext));
            _repositoryProvider = repositoryProvider;
        }

        public virtual int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

    }
}