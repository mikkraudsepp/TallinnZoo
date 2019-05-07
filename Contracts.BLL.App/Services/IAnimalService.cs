using Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using Domain;
using Domain.Animals;

namespace Contracts.BLL.App.Services
{
    public interface IAnimalService  : IBaseEntityService<Animal>, IAnimalRepository
    {
        
    }
}
