

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
    public class AnimalService : BaseEntityService<Animal, IAppUnitOfWork>, IAnimalService
    {
        public AnimalService(IAppUnitOfWork uow) : base(uow)
        {
            
        }

        public async Task<IEnumerable<Animal>> AllAsync(Guid animalId)
        {
            return await UOW.Animals.AllAsync();
        }
        
        public async Task<IEnumerable<SoundTrack>> AnimalSoundTracksAsync(Guid animalId)
        {
            return await UOW.SoundTrackInAnimals.FindSoundTrackByAnimalAsync(animalId);
        }
    }
}