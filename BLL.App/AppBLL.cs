using System;
using BLL.App.Services;
using BLL.Base;
using Contracts.BLL.App;
using Contracts.BLL.App.Services;
using Contracts.BLL.Base.Helpers;
using Contracts.DAL.App;
using Contracts.DAL.Base;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.App
{
    public class AppBLL :  BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        public AppBLL(IAppUnitOfWork uow, IBaseServiceProvider serviceProvider) : base(uow, serviceProvider)
        {
        }

        public IAnimalService Animals => ServiceProvider.GetService<IAnimalService>();
        public IFeedbackService Feedbacks => ServiceProvider.GetService<IFeedbackService>();
        public IConservationStatusService ConservationStatuses => ServiceProvider.GetService<IConservationStatusService>();
        public IAppMapService AppMaps => ServiceProvider.GetService<IAppMapService>();
        public IMapSegmentService MapSegments => ServiceProvider.GetService<IMapSegmentService>();
        public IMediaService Medias => ServiceProvider.GetService<IMediaService>();
        public ISoundTrackService SoundTracks => ServiceProvider.GetService<ISoundTrackService>();
        public IMediaInAnimalService MediaInAnimals => ServiceProvider.GetService<IMediaInAnimalService>();
        public ISoundTrackInAnimalService SoundTrackInAnimals => ServiceProvider.GetService<ISoundTrackInAnimalService>();
        public IAnimalFactService AnimalFacts => ServiceProvider.GetService<IAnimalFactService>();
    }
}