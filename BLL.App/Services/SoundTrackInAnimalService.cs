

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
    public class SoundTrackInAnimalService : BaseEntityService<SoundTrackInAnimal, IAppUnitOfWork>, ISoundTrackInAnimalService
    {
        public SoundTrackInAnimalService(IAppUnitOfWork uow) : base(uow)
        {
            
        }

        public async Task<IEnumerable<SoundTrack>> FindSoundTrackByAnimalAsync(Guid animalId)
        {
            return await UOW.SoundTrackInAnimals.FindSoundTrackByAnimalAsync(animalId);
        }
    }

}
