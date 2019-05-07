using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;
using Domain.Animals;

namespace Contracts.DAL.App.Repositories
{
    public interface ISoundTrackInAnimalRepository : IBaseRepositoryAsync<SoundTrackInAnimal>
    {
        Task<IEnumerable<SoundTrack>> FindSoundTrackByAnimalAsync(Guid animalId);
    }
}