using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base;
using DAL.Base.EF.Repositories;
using Domain;
using Domain.Animals;

namespace DAL.App.EF.Repositories
{
    public class SoundTrackInAnimalRepository : BaseRepository<SoundTrackInAnimal>, ISoundTrackInAnimalRepository
    {
        public SoundTrackInAnimalRepository(IDataContext dataContext) : base(dataContext)
        {
        }

        public Task<IEnumerable<SoundTrack>> FindSoundTrackByAnimalAsync(Guid animalId)
        {
            throw new NotImplementedException();
        }
    }
}