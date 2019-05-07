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
    public class MediaInAnimalRepository : BaseRepository<MediaInAnimal>, IMediaInAnimalRepository
    {
        public MediaInAnimalRepository(IDataContext dataContext) : base(dataContext)
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