using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.DAL.Base.Repositories;
using Domain;
using Domain.Animals;

namespace Contracts.DAL.App.Repositories
{
    public interface IMediaInAnimalRepository : IBaseRepositoryAsync<MediaInAnimal>
    {
        Task<IEnumerable<Media>> FindImageByAnimalAsync(int animalId);
    }
}