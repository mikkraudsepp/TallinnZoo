

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Domain;
using Domain.Animals;

namespace BLL.App.Services
{
    public class MediaInAnimalService : BaseEntityService<MediaInAnimal, IAppUnitOfWork>, IMediaInAnimalService
    {
        public MediaInAnimalService(IAppUnitOfWork uow) : base(uow)
        {
            
        }

        public Task<IEnumerable<Media>> FindImageByAnimalAsync(int animalId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Media>> FindSoundTrackByAnimalAsync(int animalId)
        {
            throw new NotImplementedException();
        }
    }

}
